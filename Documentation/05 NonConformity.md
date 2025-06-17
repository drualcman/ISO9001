# Módulo siguiente: Gestión de No Conformidades (Non-Conformity Management)
### Objetivo ISO 9001
Permitir que, ante errores detectados (ya sea en pedidos, productos enviados, pagos, reclamos, etc.), se registre, evalúe y trate cada caso para prevenir su repetición.

## Entidad NonConformity
```csharp
public class NonConformity
{
    public Guid Id { get; set; }
    public DateTime ReportedAt { get; set; }
    public string ReportedBy { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AffectedProcess { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Correction { get; set; } = string.Empty;
    public string CorrectiveAction { get; set; } = string.Empty;
    public string Status { get; set; } = "Open";  // Open, Closed
    public DateTime? ResolvedAt { get; set; }  // Fecha de resolución
    public string ResolutionDetails { get; set; } = string.Empty;  // Detalles de la resolución
    public string ResolvedBy { get; set; } = string.Empty;  // Quién resolvió
}
```
## Casos de uso principales
- RegisterNonConformity
- ResolveNonConformity
- ListNonConformities

## Request / Response DTOs
```csharp
public class RegisterNonConformityRequest
{
    public string ReportedBy { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AffectedProcess { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Correction { get; set; } = string.Empty;
    public string CorrectiveAction { get; set; } = string.Empty;
}

public class RegisterNonConformityResponse
{
    public Guid Id { get; set; }
    public DateTime ReportedAt { get; set; }
}
```
## InputPort / OutputPort
```csharp
public interface IRegisterNonConformityInputPort
{
    Task HandleAsync(RegisterNonConformityRequest request);
}

public interface IRegisterNonConformityOutputPort
{
    Task HandleAsync(RegisterNonConformityResponse response);
}
```

## Interactor
```csharp
public class RegisterNonConformityInteractor : IRegisterNonConformityInputPort
{
    private readonly INonConformityRepository repository;
    private readonly IRegisterNonConformityOutputPort outputPort;

    public RegisterNonConformityInteractor(
        INonConformityRepository repository,
        IRegisterNonConformityOutputPort outputPort)
    {
        this.repository = repository;
        this.outputPort = outputPort;
    }

    public async Task HandleAsync(RegisterNonConformityRequest request)
    {
        NonConformity nonConformity = new NonConformity
        {
            Id = Guid.NewGuid(),
            ReportedAt = DateTime.UtcNow,
            ReportedBy = request.ReportedBy,
            Description = request.Description,
            AffectedProcess = request.AffectedProcess,
            Cause = request.Cause,
            Correction = request.Correction,
            CorrectiveAction = request.CorrectiveAction,
            Status = "Open"
        };

        await repository.SaveAsync(nonConformity);

        RegisterNonConformityResponse response = new RegisterNonConformityResponse
        {
            Id = nonConformity.Id,
            ReportedAt = nonConformity.ReportedAt
        };

        await outputPort.HandleAsync(response);
    }
}
```

## Presenter: RegisterNonConformityPresenter
El presenter es el que conecta el interactor con el ViewModel. En este caso, el presenter recibirá la respuesta del interactor y actualizará el ViewModel.

```csharp
public class RegisterNonConformityPresenter : IRegisterNonConformityOutputPort
{
    private readonly RegisterNonConformityViewModel viewModel;

    public RegisterNonConformityPresenter(RegisterNonConformityViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task HandleAsync(RegisterNonConformityResponse response)
    {
        viewModel.NonConformityId = response.Id;
        viewModel.ReportedAt = response.ReportedAt;
        viewModel.Status = "Non-conformity registered successfully";
        return Task.CompletedTask;
    }
}
```

## ViewModel: RegisterNonConformityViewModel
El viewmodel se usa para representar los datos que se mostrarán en la interfaz de usuario, y debe implementarse para que Blazor lo pueda enlazar (con INotifyPropertyChanged).

```csharp
public class RegisterNonConformityViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string reportedBy = string.Empty;
    private string description = string.Empty;
    private string affectedProcess = string.Empty;
    private string cause = string.Empty;
    private string correction = string.Empty;
    private string correctiveAction = string.Empty;
    private string status = string.Empty;
    private Guid nonConformityId;
    private DateTime reportedAt;

    public string ReportedBy
    {
        get => reportedBy;
        set
        {
            if (reportedBy != value)
            {
                reportedBy = value;
                NotifyPropertyChanged(nameof(ReportedBy));
            }
        }
    }

    public string Description
    {
        get => description;
        set
        {
            if (description != value)
            {
                description = value;
                NotifyPropertyChanged(nameof(Description));
            }
        }
    }

    public string AffectedProcess
    {
        get => affectedProcess;
        set
        {
            if (affectedProcess != value)
            {
                affectedProcess = value;
                NotifyPropertyChanged(nameof(AffectedProcess));
            }
        }
    }

    public string Cause
    {
        get => cause;
        set
        {
            if (cause != value)
            {
                cause = value;
                NotifyPropertyChanged(nameof(Cause));
            }
        }
    }

    public string Correction
    {
        get => correction;
        set
        {
            if (correction != value)
            {
                correction = value;
                NotifyPropertyChanged(nameof(Correction));
            }
        }
    }

    public string CorrectiveAction
    {
        get => correctiveAction;
        set
        {
            if (correctiveAction != value)
            {
                correctiveAction = value;
                NotifyPropertyChanged(nameof(CorrectiveAction));
            }
        }
    }

    public string Status
    {
        get => status;
        set
        {
            if (status != value)
            {
                status = value;
                NotifyPropertyChanged(nameof(Status));
            }
        }
    }

    public Guid NonConformityId
    {
        get => nonConformityId;
        set
        {
            if (nonConformityId != value)
            {
                nonConformityId = value;
                NotifyPropertyChanged(nameof(NonConformityId));
            }
        }
    }

    public DateTime ReportedAt
    {
        get => reportedAt;
        set
        {
            if (reportedAt != value)
            {
                reportedAt = value;
                NotifyPropertyChanged(nameof(ReportedAt));
            }
        }
    }

    private void NotifyPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```

## Componente Blazor: RegisterNonConformity.razor
Ahora, vamos a crear un formulario en Blazor que permita registrar una no conformidad. Usaremos Bulma CSS para el diseño del formulario.

```razor
@page "/register-nonconformity"
@inject IRegisterNonConformityInputPort RegisterNonConformityInputPort
@inject NavigationManager Navigation

@code {
    private RegisterNonConformityViewModel viewModel = new RegisterNonConformityViewModel();
    private RegisterNonConformityPresenter? presenter;

    protected override async Task OnInitializedAsync()
    {
        presenter = new RegisterNonConformityPresenter(viewModel);
    }

    private async Task HandleSubmit()
    {
        RegisterNonConformityRequest request = new RegisterNonConformityRequest
        {
            ReportedBy = viewModel.ReportedBy,
            Description = viewModel.Description,
            AffectedProcess = viewModel.AffectedProcess,
            Cause = viewModel.Cause,
            Correction = viewModel.Correction,
            CorrectiveAction = viewModel.CorrectiveAction
        };

        await RegisterNonConformityInputPort.HandleAsync(request);
        Navigation.NavigateTo("/nonconformity-confirmation");
    }
}

<div class="container">
    <h3 class="title is-4">Register a Non-Conformity</h3>

    <div class="box">
        <div class="field">
            <label class="label">Reported By</label>
            <div class="control">
                <input class="input" type="text" @bind="viewModel.ReportedBy" placeholder="Your name" />
            </div>
        </div>

        <div class="field">
            <label class="label">Description</label>
            <div class="control">
                <textarea class="textarea" @bind="viewModel.Description" placeholder="Description of the non-conformity"></textarea>
            </div>
        </div>

        <div class="field">
            <label class="label">Affected Process</label>
            <div class="control">
                <input class="input" type="text" @bind="viewModel.AffectedProcess" placeholder="Process affected" />
            </div>
        </div>

        <div class="field">
            <label class="label">Cause</label>
            <div class="control">
                <input class="input" type="text" @bind="viewModel.Cause" placeholder="Root cause of the issue" />
            </div>
        </div>

        <div class="field">
            <label class="label">Correction</label>
            <div class="control">
                <input class="input" type="text" @bind="viewModel.Correction" placeholder="Immediate correction applied" />
            </div>
        </div>

        <div class="field">
            <label class="label">Corrective Action</label>
            <div class="control">
                <input class="input" type="text" @bind="viewModel.CorrectiveAction" placeholder="Action to prevent recurrence" />
            </div>
        </div>

        <button class="button is-primary" @onclick="HandleSubmit">Submit</button>
    </div>

    @if (!string.IsNullOrEmpty(viewModel.Status))
    {
        <div class="notification is-success">
            @viewModel.Status
        </div>
    }
</div>
```

### Resumiendo:
- Entidad NonConformity: Define la estructura de los datos.
- Caso de Uso RegisterNonConformity: La lógica de registro.
- Presenter RegisterNonConformityPresenter: Actualiza el ViewModel con el estado tras el registro.
- ViewModel RegisterNonConformityViewModel: Maneja los datos de la UI y las notificaciones.
- Componente Blazor RegisterNonConformity.razor: Interfaz de usuario con formulario para registrar no conformidades.