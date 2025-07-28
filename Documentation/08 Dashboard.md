# Dashboard de Calidad
Es esencial para ISO 9001, ya que permite monitorear indicadores clave (KPIs) del sistema de gestión de calidad.

### Objetivo del Dashboard de Calidad
Mostrar visualmente en Blazor los siguientes indicadores:

- Número de no conformidades abiertas/cerradas.
- Tiempo promedio de resolución de no conformidades.
- Cantidad de feedbacks recibidos vs. calificación promedio.
- Pedidos con mayor número de incidencias.
- Tendencias mensuales de no conformidades y feedback.
- Estos datos ayudarán al Responsable de Calidad a identificar problemas recurrentes, evaluar mejoras y preparar auditorías.

## Entidades del Dominio para KPIs
Ya tenemos NonConformity y CustomerFeedback, pero necesitamos una entidad para QualityReport solo si deseamos persistir snapshots históricos. Si es en tiempo real, usaremos directamente queries al repositorio.

## Caso de Uso – Obtener KPIs de Calidad
### Request:
```csharp
public sealed class GetQualityDashboardRequest
{
    public DateTime From { get; }
    public DateTime To { get; }

    public GetQualityDashboardRequest(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }
}
```
### Output:
```csharp
public sealed class QualityDashboardResponse
{
    public int OpenNonConformities { get; set; }
    public int ClosedNonConformities { get; set; }
    public double AverageResolutionDays { get; set; }
    public int TotalFeedbacks { get; set; }
    public double AverageRating { get; set; }
    public Dictionary<string, int> IncidentsPerOrder { get; set; } = new();
    public List<MonthlyQualityKpi> MonthlyKpis { get; set; } = new();
}

public sealed class MonthlyQualityKpi
{
    public string Month { get; set; } = string.Empty;
    public int NonConformities { get; set; }
    public int Feedbacks { get; set; }
}
```

### InputPort y OutputPort:
```csharp
public interface IGetQualityDashboardUseCase
{
    Task HandleAsync(GetQualityDashboardRequest request, IQualityDashboardOutputPort outputPort);
}

public interface IQualityDashboardOutputPort
{
    Task PresentAsync(QualityDashboardResponse response);
}
```

### Interactor – GetQualityDashboardInteractor
```csharp
public sealed class GetQualityDashboardInteractor : IGetQualityDashboardUseCase
{
    private readonly INonConformityRepository _nonConformityRepository;
    private readonly ICustomerFeedbackRepository _feedbackRepository;

    public GetQualityDashboardInteractor(
        INonConformityRepository nonConformityRepository,
        ICustomerFeedbackRepository feedbackRepository)
    {
        _nonConformityRepository = nonConformityRepository;
        _feedbackRepository = feedbackRepository;
    }

    public async Task HandleAsync(GetQualityDashboardRequest request, IQualityDashboardOutputPort outputPort)
    {
        List<NonConformity> nonConformities = await _nonConformityRepository.GetByDateRangeAsync(request.From, request.To);
        List<CustomerFeedback> feedbacks = await _feedbackRepository.GetByDateRangeAsync(request.From, request.To);

        int openCount = 0;
        int closedCount = 0;
        double totalDaysToResolve = 0;
        int resolvedCount = 0;
        Dictionary<string, int> incidentsPerOrder = new();
        Dictionary<string, MonthlyQualityKpi> monthly = new();

        foreach (NonConformity nc in nonConformities)
        {
            if (nc.IsResolved)
            {
                closedCount++;
                if (nc.ResolutionDate.HasValue)
                {
                    TimeSpan duration = nc.ResolutionDate.Value - nc.ReportedAt;
                    totalDaysToResolve += duration.TotalDays;
                    resolvedCount++;
                }
            }
            else
            {
                openCount++;
            }

            if (!string.IsNullOrWhiteSpace(nc.RelatedOrderId))
            {
                if (!incidentsPerOrder.ContainsKey(nc.RelatedOrderId))
                {
                    incidentsPerOrder[nc.RelatedOrderId] = 0;
                }

                incidentsPerOrder[nc.RelatedOrderId]++;
            }

            string monthKey = nc.ReportedAt.ToString("yyyy-MM");
            if (!monthly.ContainsKey(monthKey))
            {
                monthly[monthKey] = new MonthlyQualityKpi { Month = monthKey };
            }

            monthly[monthKey].NonConformities++;
        }

        int feedbackTotal = feedbacks.Count;
        double averageRating = 0;

        if (feedbackTotal > 0)
        {
            averageRating = feedbacks.Average(f => f.Rating);

            foreach (CustomerFeedback fb in feedbacks)
            {
                string monthKey = fb.ReceivedAt.ToString("yyyy-MM");
                if (!monthly.ContainsKey(monthKey))
                {
                    monthly[monthKey] = new MonthlyQualityKpi { Month = monthKey };
                }

                monthly[monthKey].Feedbacks++;
            }
        }

        double averageResolution = resolvedCount > 0 ? totalDaysToResolve / resolvedCount : 0;

        QualityDashboardResponse response = new QualityDashboardResponse
        {
            OpenNonConformities = openCount,
            ClosedNonConformities = closedCount,
            AverageResolutionDays = averageResolution,
            TotalFeedbacks = feedbackTotal,
            AverageRating = averageRating,
            IncidentsPerOrder = incidentsPerOrder
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
            MonthlyKpis = monthly.Values.OrderBy(kpi => kpi.Month).ToList()
        };

        await outputPort.PresentAsync(response);
    }
}
```

## Repositories
Implementar los repositorios necesarios para que el interactor del Dashboard funcione correctamente. Nos enfocamos en:

- INonConformityRepository
- ICustomerFeedbackRepository

Cada uno debe exponer un método GetByDateRangeAsync que permita recuperar la información necesaria.

### Interfaz del Repositorio de No Conformidades
```csharp
public interface INonConformityRepository
{
    Task<List<NonConformity>> GetByDateRangeAsync(DateTime from, DateTime to);
}
```
Ejemplo de implementación en memoria (puedes luego adaptarlo a Entity Framework o lo que uses):
```csharp
public sealed class InMemoryNonConformityRepository : INonConformityRepository
{
    private readonly List<NonConformity> _storage = new();

    public Task<List<NonConformity>> GetByDateRangeAsync(DateTime from, DateTime to)
    {
        List<NonConformity> result = _storage
            .Where(nc => nc.ReportedAt >= from && nc.ReportedAt <= to)
            .ToList();

        return Task.FromResult(result);
    }

    // Puedes añadir métodos como AddAsync, UpdateAsync, etc. si es necesario.
}
```
### Interfaz del Repositorio de Feedback del Cliente
```csharp
public interface ICustomerFeedbackRepository
{
    Task<List<CustomerFeedback>> GetByDateRangeAsync(DateTime from, DateTime to);
}
```
Implementación en memoria:
```csharp
public sealed class InMemoryCustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly List<CustomerFeedback> _storage = new();

    public Task<List<CustomerFeedback>> GetByDateRangeAsync(DateTime from, DateTime to)
    {
        List<CustomerFeedback> result = _storage
            .Where(f => f.ReceivedAt >= from && f.ReceivedAt <= to)
            .ToList();

        return Task.FromResult(result);
    }
}
```
Estas implementaciones en memoria nos sirven como prueba o para testing. Luego puedes crear versiones específicas que usen EF Core u otra tecnología en la infraestructura.

## Presentador – QualityDashboardPresenter
```csharp
public sealed class QualityDashboardPresenter : IQualityDashboardOutputPort
{
    private readonly QualityDashboardViewModel _viewModel;

    public QualityDashboardPresenter(QualityDashboardViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public Task PresentAsync(QualityDashboardResponse response)
    {
        _viewModel.OpenNonConformities = response.OpenNonConformities;
        _viewModel.ClosedNonConformities = response.ClosedNonConformities;
        _viewModel.AverageResolutionDays = response.AverageResolutionDays;
        _viewModel.TotalFeedbacks = response.TotalFeedbacks;
        _viewModel.AverageRating = response.AverageRating;
        _viewModel.IncidentsPerOrder = response.IncidentsPerOrder;
        _viewModel.MonthlyKpis = response.MonthlyKpis;

        _viewModel.HasData = true;

        return Task.CompletedTask;
    }
}
```
## ViewModel – QualityDashboardViewModel
```csharp
public sealed class QualityDashboardViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public int OpenNonConformities { get; set; }

    public int ClosedNonConformities { get; set; }

    public double AverageResolutionDays { get; set; }

    public int TotalFeedbacks { get; set; }

    public double AverageRating { get; set; }

    public Dictionary<string, int> IncidentsPerOrder { get; set; } = new();

    public List<MonthlyQualityKpi> MonthlyKpis { get; set; } = new();

    public bool HasData { get; set; }

    public void Clear()
    {
        OpenNonConformities = 0;
        ClosedNonConformities = 0;
        AverageResolutionDays = 0;
        TotalFeedbacks = 0;
        AverageRating = 0;
        IncidentsPerOrder.Clear();
        MonthlyKpis.Clear();
        HasData = false;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
```

# Dashboard en Blazor – Página .razor
La estructura básica de la página Blazor tendrá las siguientes secciones:
- Encabezado con estadísticas generales.
- Tabla con los incidentes por pedido.
- Gráficos o tablas con KPIs mensuales.
 
## Empezamos con la página .razor.
```razor
@page "/quality-dashboard"
@inject IGetQualityDashboardUseCase DashboardUseCase
@inject QualityDashboardPresenter DashboardPresenter
@inject QualityDashboardViewModel DashboardViewModel

@{
    // Set up dates (you can use current date or range, here we use last 30 days)
    DateTime fromDate = DateTime.Now.AddDays(-30);
    DateTime toDate = DateTime.Now;

    // Trigger dashboard loading when component is initialized
    Task.Run(() => DashboardUseCase.HandleAsync(new GetQualityDashboardRequest(fromDate, toDate), DashboardPresenter));
}

<div class="container mt-5">
    <h1 class="title is-3">Quality Dashboard</h1>

    @if (DashboardViewModel.HasData)
    {
        <!-- General Statistics -->
        <div class="columns is-multiline">
            <div class="column is-one-third">
                <div class="box">
                    <p class="title is-5">Open Non-Conformities</p>
                    <p class="subtitle is-4">@DashboardViewModel.OpenNonConformities</p>
                </div>
            </div>

            <div class="column is-one-third">
                <div class="box">
                    <p class="title is-5">Closed Non-Conformities</p>
                    <p class="subtitle is-4">@DashboardViewModel.ClosedNonConformities</p>
                </div>
            </div>

            <div class="column is-one-third">
                <div class="box">
                    <p class="title is-5">Average Resolution Time (Days)</p>
                    <p class="subtitle is-4">@DashboardViewModel.AverageResolutionDays</p>
                </div>
            </div>
        </div>

        <!-- Customer Feedback -->
        <div class="columns is-multiline">
            <div class="column is-half">
                <div class="box">
                    <p class="title is-5">Total Feedbacks</p>
                    <p class="subtitle is-4">@DashboardViewModel.TotalFeedbacks</p>
                </div>
            </div>

            <div class="column is-half">
                <div class="box">
                    <p class="title is-5">Average Rating</p>
                    <p class="subtitle is-4">@DashboardViewModel.AverageRating</p>
                </div>
            </div>
        </div>

        <!-- Incidents by Order -->
        <div class="box">
            <p class="title is-5">Incidents by Order</p>
            <table class="table is-fullwidth">
                <thead>
                    <tr>
                        <th>Order ID</th>
                        <th>Incidents</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var order in DashboardViewModel.IncidentsPerOrder)
                    {
                        <tr>
                            <td>@order.Key</td>
                            <td>@order.Value</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>

        <!-- Monthly KPIs -->
        <div class="box">
            <p class="title is-5">Monthly KPIs</p>
            <table class="table is-fullwidth">
                <thead>
                    <tr>
                        <th>Month</th>
                        <th>Non-Conformities</th>
                        <th>Feedbacks</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var kpi in DashboardViewModel.MonthlyKpis)
                    {
                        <tr>
                            <td>@kpi.Month</td>
                            <td>@kpi.NonConformities</td>
                            <td>@kpi.Feedbacks</td>
                        </tr>
                    }
                </tbody>
            </table>
        </div>
    }
    else
    {
        <div class="notification is-info">
            <p>No data available for the selected time period.</p>
        </div>
    }
</div>
```
### Explicación de la Página:
Encabezado General:

- Se muestra el número de Non-Conformities abiertas y cerradas, y el promedio de resolución en días.
- Se muestran las estadísticas de feedbacks y la calificación promedio.

- Incidentes por Pedido:

- Una tabla muestra el número de incidentes relacionados con cada pedido.
- KPIs Mensuales:
- Una tabla muestra los KPIs mensuales, que incluyen el número de non-conformities y feedbacks por mes.

### CSS y Estilo con Bulma:
El uso de Bulma es sencillo, sin necesidad de añadir mucho CSS extra, solo usando las clases estándar de Bulma.

Las tablas son responsivas y la interfaz se adapta para ver las métricas de calidad de manera clara.


