# Nuevos Casos ISO 9001 que podemos implementar después
Ya tenemos cubiertos:

- Trazabilidad de pedidos (PlaceOrder + AuditLog)
- Trazabilidad de pagos (RegisterPayment + AuditLog)

## Nuevo caso de uso: ReportIncident (gestión de incidencias)
Permite cumplir con el requisito de gestión de no conformidades y acciones correctivas.

### Entidad: IncidentReport
```csharp
public class IncidentReport
{
    public int Id { get; set; }
    public DateTime ReportedAt { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public string AffectedProcess { get; set; } // "Order", "Payment", etc.
    public string Severity { get; set; } // "Low", "Medium", "High"
}
```
### InputPort / OutputPort / Interactor
```csharp
public interface IReportIncidentInputPort
{
    Task HandleAsync(ReportIncidentRequest request);
}

public interface IReportIncidentOutputPort
{
    Task HandleAsync(ReportIncidentResponse response);
    Task Invalid(string reason);
}

public class ReportIncidentRequest
{
    public int UserId { get; set; }
    public string Description { get; set; }
    public string AffectedProcess { get; set; }
    public string Severity { get; set; }
}

public class ReportIncidentResponse
{
    public int IncidentId { get; set; }
}
```
### Interactor
```csharp
public class ReportIncidentInteractor : IReportIncidentInputPort
{
    private readonly IReportIncidentOutputPort outputPort;
    private readonly IIncidentRepository incidentRepository;

    public ReportIncidentInteractor(
        IReportIncidentOutputPort outputPort,
        IIncidentRepository incidentRepository)
    {
        this.outputPort = outputPort;
        this.incidentRepository = incidentRepository;
    }

    public async Task HandleAsync(ReportIncidentRequest request)
    {
        IncidentReport incident = new IncidentReport
        {
            UserId = request.UserId,
            Description = request.Description,
            AffectedProcess = request.AffectedProcess,
            Severity = request.Severity,
            ReportedAt = DateTime.UtcNow
        };

        await incidentRepository.SaveAsync(incident);

        ReportIncidentResponse response = new ReportIncidentResponse
        {
            IncidentId = incident.Id
        };

        await outputPort.HandleAsync(response);
    }
}
```

### ViewModel: ReportIncidentVM
```csharp
public class ReportIncidentVM
{
    private readonly IReportIncidentInputPort inputPort;
    private readonly IReportIncidentOutputPort outputPort;

    public string Description { get; set; }
    public string AffectedProcess { get; set; } = "Order";
    public string Severity { get; set; } = "Medium";
    public string? Message { get; private set; }

    public ReportIncidentVM(
        IReportIncidentInputPort inputPort,
        IReportIncidentOutputPort outputPort)
    {
        this.inputPort = inputPort;
        this.outputPort = outputPort;
    }

    public async Task SubmitAsync(int userId)
    {
        Message = null;

        ReportIncidentRequest request = new ReportIncidentRequest
        {
            UserId = userId,
            Description = Description,
            AffectedProcess = AffectedProcess,
            Severity = Severity
        };

        await inputPort.HandleAsync(request);
    }

    public void ShowResult(string result)
    {
        Message = result;
    }
}
```
### Presenter: ReportIncidentPresenter
```csharp
public class ReportIncidentPresenter : IReportIncidentOutputPort
{
    private readonly ReportIncidentVM viewModel;

    public ReportIncidentPresenter(ReportIncidentVM viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task HandleAsync(ReportIncidentResponse response)
    {
        viewModel.ShowResult($"Incident #{response.IncidentId} reported successfully.");
        return Task.CompletedTask;
    }

    public Task Invalid(string reason)
    {
        viewModel.ShowResult($"Failed to report incident: {reason}");
        return Task.CompletedTask;
    }
}
```
### Componente Razor: ReportIncident.razor
```razor
@page "/report-incident"
@inject ReportIncidentVM ViewModel

<h3 class="title is-4">Report an Incident</h3>

<div class="field">
    <label class="label">Description</label>
    <div class="control">
        <textarea class="textarea" @bind="ViewModel.Description"></textarea>
    </div>
</div>

<div class="field">
    <label class="label">Affected Process</label>
    <div class="control">
        <div class="select">
            <select @bind="ViewModel.AffectedProcess">
                <option>Order</option>
                <option>Payment</option>
                <option>Shipping</option>
            </select>
        </div>
    </div>
</div>

<div class="field">
    <label class="label">Severity</label>
    <div class="control">
        <div class="select">
            <select @bind="ViewModel.Severity">
                <option>Low</option>
                <option>Medium</option>
                <option>High</option>
            </select>
        </div>
    </div>
</div>

<div class="field">
    <div class="control">
        <button class="button is-danger" @onclick="SubmitIncident">Submit</button>
    </div>
</div>

@if (!string.IsNullOrWhiteSpace(ViewModel.Message))
{
    <div class="notification is-info mt-4">
        @ViewModel.Message
    </div>
}

@code {
    private async Task SubmitIncident()
    {
        await ViewModel.SubmitAsync(userId: 123); // Simulated user ID
    }
}
```
### DI Registration (por si lo necesitas)
```csharp
builder.Services.AddScoped<ReportIncidentVM>(sp =>
{
    ReportIncidentVM vm = new ReportIncidentVM(
        sp.GetRequiredService<IReportIncidentInputPort>(),
        new ReportIncidentPresenter(null!)
    );
    ReportIncidentPresenter presenter = new ReportIncidentPresenter(vm);
    typeof(ReportIncidentPresenter).GetField("viewModel", BindingFlags.NonPublic | BindingFlags.Instance)
        ?.SetValue(presenter, vm);
    return vm;
});
```