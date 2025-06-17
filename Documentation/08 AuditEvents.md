# Panel de auditoría
## Entidades del Dominio (Auditoría)
Primero definimos la entidad principal:

```csharp
public sealed class AuditEvent
{
    public Guid Id { get; }
    public Guid OrderId { get; }
    public DateTime Timestamp { get; }
    public string EventType { get; } // e.g., "OrderCreated", "PaymentReceived", "NonConformityReported"
    public string Description { get; }
    public string ResponsibleUser { get; }

    public AuditEvent(Guid id, Guid orderId, DateTime timestamp, string eventType, string description, string responsibleUser)
    {
        Id = id;
        OrderId = orderId;
        Timestamp = timestamp;
        EventType = eventType;
        Description = description;
        ResponsibleUser = responsibleUser;
    }
}
```

## Caso de Uso: Obtener Auditoría por Pedido
Input Port
```csharp
public interface IGetAuditLogByOrderUseCase
{
    Task HandleAsync(GetAuditLogByOrderRequest request, IAuditLogOutputPort outputPort);
}
```
## Request DTO
```csharp
public sealed class GetAuditLogByOrderRequest
{
    public Guid OrderId { get; }

    public GetAuditLogByOrderRequest(Guid orderId)
    {
        OrderId = orderId;
    }
}
```
## Output Port
Este puerto será implementado por el presentador, que preparará los datos para la capa de presentación:

```csharp
public interface IAuditLogOutputPort
{
    Task PresentAsync(IEnumerable<AuditEvent> auditEvents);
}
```

## Interactor (Caso de uso)
El interactor coordina la lógica y se apoya en un repositorio que obtiene los eventos por OrderId.

```csharp
public sealed class GetAuditLogByOrderInteractor : IGetAuditLogByOrderUseCase
{
    private readonly IAuditLogRepository _repository;

    public GetAuditLogByOrderInteractor(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(GetAuditLogByOrderRequest request, IAuditLogOutputPort outputPort)
    {
        IEnumerable<AuditEvent> auditEvents = await _repository.GetByOrderIdAsync(request.OrderId);

        await outputPort.PresentAsync(auditEvents);
    }
}
```

## Repositorio
La abstracción para obtener los eventos desde la infraestructura:

```csharp
public interface IAuditLogRepository
{
    Task<IEnumerable<AuditEvent>> GetByOrderIdAsync(Guid orderId);
}
```

## Implementación del Repositorio (AuditLogRepository)
Esta clase accede a la fuente de datos. Usaremos una clase base simple como si estuviera accediendo a una base de datos relacional (o archivo de log en una implementación real).

Supongamos que ya tienes una DbContext o equivalente. Si no, esta parte se puede adaptar a tu persistencia.
```csharp
public sealed class AuditLogRepository : IAuditLogRepository
{
    private readonly ApplicationDbContext _context;

    public AuditLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AuditEvent>> GetByOrderIdAsync(Guid orderId)
    {
        List<AuditEventEntity> entities = await _context.AuditEvents
            .Where(e => e.OrderId == orderId)
            .OrderBy(e => e.Timestamp)
            .ToListAsync();

        List<AuditEvent> result = new List<AuditEvent>();

        foreach (AuditEventEntity entity in entities)
        {
            AuditEvent auditEvent = new AuditEvent(
                entity.Id,
                entity.OrderId,
                entity.Timestamp,
                entity.EventType,
                entity.Description,
                entity.ResponsibleUser
            );

            result.Add(auditEvent);
        }

        return result;
    }
}
```
Donde AuditEventEntity sería la clase de entidad mapeada para persistencia.

## Entidad de Infraestructura (AuditEventEntity)
```csharp
public sealed class AuditEventEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime Timestamp { get; set; }
    public string EventType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ResponsibleUser { get; set; } = string.Empty;
}
```

## ViewModel (para la UI)
Primero definimos el ViewModel que usará la vista de Blazor:

```csharp
public sealed class AuditLogViewModel
{
    public List<AuditLogItemViewModel> Events { get; } = new List<AuditLogItemViewModel>();
}

public sealed class AuditLogItemViewModel
{
    public string EventType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Timestamp { get; set; } = string.Empty;
    public string ResponsibleUser { get; set; } = string.Empty;
}
```

## Presentador (AuditLogPresenter)
Este presentador implementa el IAuditLogOutputPort y llena el AuditLogViewModel con datos legibles por el UI:

```csharp
public sealed class AuditLogPresenter : IAuditLogOutputPort
{
    private readonly AuditLogViewModel _viewModel;

    public AuditLogPresenter(AuditLogViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public Task PresentAsync(IEnumerable<AuditEvent> auditEvents)
    {
        _viewModel.Events.Clear();

        foreach (AuditEvent auditEvent in auditEvents)
        {
            AuditLogItemViewModel item = new AuditLogItemViewModel
            {
                EventType = auditEvent.EventType,
                Description = auditEvent.Description,
                Timestamp = auditEvent.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                ResponsibleUser = auditEvent.ResponsibleUser
            };

            _viewModel.Events.Add(item);
        }

        return Task.CompletedTask;
    }
}
```
Este patrón mantiene el ViewModel limpio y sin referencias a clases del dominio ni a la infraestructura, lo cual es esencial para el desacoplamiento.

## ViewModel de Blazor (Binding para la Vista)
Creamos una clase que actúa como Model en el patrón MVVM (la lógica del componente se separa aquí):

```csharp
public sealed class AuditLogPageModel
{
    public AuditLogViewModel ViewModel { get; } = new AuditLogViewModel();

    private readonly IGetAuditLogByOrderUseCase _useCase;
    private readonly AuditLogPresenter _presenter;

    public AuditLogPageModel(IGetAuditLogByOrderUseCase useCase)
    {
        _presenter = new AuditLogPresenter(ViewModel);
        _useCase = useCase;
    }

    public async Task LoadAsync(Guid orderId)
    {
        GetAuditLogByOrderRequest request = new GetAuditLogByOrderRequest(orderId);
        await _useCase.HandleAsync(request, _presenter);
    }
}
```

## Componente Blazor – AuditLog.razor
Este es el componente de interfaz que usará Bulma para mostrar los eventos:

```razor
@page "/orders/{OrderId:guid}/audit"
@inject IGetAuditLogByOrderUseCase UseCase

@code {
    [Parameter]
    public Guid OrderId { get; set; }

    private AuditLogPageModel model = default!;
    private bool isLoaded = false;

    protected override async Task OnInitializedAsync()
    {
        model = new AuditLogPageModel(UseCase);
        await model.LoadAsync(OrderId);
        isLoaded = true;
    }
}
@if (!isLoaded)
{
    <p class="has-text-centered">Loading audit log...</p>
}
else
{
    <div class="box">
        <h1 class="title is-4">Audit Trail</h1>

        <table class="table is-striped is-fullwidth">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Event</th>
                    <th>Description</th>
                    <th>Responsible</th>
                </tr>
            </thead>
            <tbody>
                @foreach (AuditLogItemViewModel item in model.ViewModel.Events)
                {
                    <tr>
                        <td>@item.Timestamp</td>
                        <td>@item.EventType</td>
                        <td>@item.Description</td>
                        <td>@item.ResponsibleUser</td>
                    </tr>
                }
            </tbody>
        </table>
    </div>
}
```
