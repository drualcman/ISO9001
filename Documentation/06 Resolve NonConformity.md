# Registro y Resolución de la No Conformidad:
La forma en que se gestionan las no conformidades en un sistema conforme a ISO 9001 depende de los flujos de trabajo definidos en la organización, pero generalmente, hay dos tipos de roles involucrados en este proceso:

## Registro de la No Conformidad:

- Opción 1: El usuario final (cliente) puede ser quien registre la no conformidad, especialmente si se trata de un producto defectuoso o servicio no satisfactorio. Esto suele hacerse a través de un formulario en la aplicación web o en el sitio de soporte de la empresa. En este caso, el cliente reporta el incidente directamente a la empresa.
- Opción 2: El usuario de la empresa (ejemplo: agente de soporte o encargado de atención al cliente) podría ser quien registre la no conformidad después de recibir la llamada, correo o cualquier otra comunicación del cliente. Este es un flujo común, ya que las empresas prefieren manejar el reporte de no conformidades desde un punto centralizado para darles seguimiento adecuado.

En ambos casos, el flujo sería similar, pero el punto de inicio (quién lo registra) cambia.

Ejemplo de flujo:

- El usuario final podría ingresar una queja en un formulario dentro de la aplicación o en un portal.
- El usuario de la empresa (por ejemplo, el agente de soporte o el responsable de calidad) recibe la queja y, si es necesario, completa un formulario similar para registrar la no conformidad internamente. El formulario puede contener más detalles sobre el producto/servicio afectado.

## Resolución de la No Conformidad:

- Opción 1: El usuario de la empresa (por ejemplo, un miembro del equipo de soporte o del departamento de calidad) es quien gestionará la resolución, siguiendo los procedimientos internos para investigar la causa, implementar las acciones correctivas y cerrar la no conformidad.
- Opción 2: El usuario final (en algunos casos específicos) podría ser informado de la resolución, pero típicamente no es quien hace la resolución directamente. Sin embargo, el cliente puede recibir notificaciones de seguimiento o resolución a través de correo electrónico o un portal de usuario.

Ejemplo de flujo:

- El usuario de la empresa (por ejemplo, el encargado de calidad o soporte técnico) investiga el problema, aplica las correcciones necesarias y documenta la resolución. Posteriormente, la no conformidad se marca como cerrada en el sistema.
- El usuario final (cliente) puede recibir una notificación o correo confirmando que la no conformidad ha sido resuelta.

# En términos de la aplicación:
Para el Registro de la No Conformidad:

- Si el cliente es quien registra la no conformidad, podrías tener un formulario o sección en la aplicación donde el cliente puede reportar problemas o incidentes relacionados con productos o servicios.
- Si el empleado de la empresa es quien lo hace, se podría incluir un panel interno donde el empleado pueda ingresar detalles de la queja o no conformidad tras recibirla por teléfono o correo electrónico.

## Para la Resolución de la No Conformidad:

El proceso de resolución generalmente será gestionado por el usuario de la empresa. Esto puede ser realizado en un panel de administración o interfaz interna para que el empleado registre las acciones correctivas y cierre la no conformidad. Sin embargo, una vez resuelta, el cliente debe recibir una notificación o confirmación de resolución (por correo electrónico o en la interfaz de usuario si es una aplicación web o móvil).

### Ejemplo de Flujo en tu Aplicación:

#### Formulario de Registro de No Conformidad para el Usuario Final (Cliente):
- Un cliente accede a una sección en la aplicación de "Soporte" o "Reportar Incidencias".
- Completa un formulario con detalles del incidente (producto defectuoso, error en el servicio, etc.).
- La no conformidad se crea en el sistema y se asigna para su investigación.

#### Panel de Gestión para el Usuario de la Empresa (Empleado):
- Un empleado (como un agente de soporte) accede a un panel de "Gestión de Incidencias" o "Gestión de No Conformidades".
- Ve una lista de incidentes reportados y puede seleccionar uno para investigar y gestionar.
- El empleado registra la resolución de la no conformidad (detalles de la acción correctiva, estado de resolución, etc.).
- La no conformidad se marca como resuelta y el cliente recibe una notificación de que el problema ha sido solucionado.

#### Notificación al Cliente:
Una vez resuelta la no conformidad, se envía una notificación al cliente confirmando que el problema ha sido resuelto, lo que puede hacerse a través de un correo electrónico, mensaje en la interfaz o ambos.

## Request / Response DTOs para Resolución
Vamos a crear los DTOs necesarios para gestionar la resolución de la no conformidad.

```csharp
public class ResolveNonConformityRequest
{
    public Guid NonConformityId { get; set; }
    public string ResolutionDetails { get; set; } = string.Empty;
    public string ResolvedBy { get; set; } = string.Empty;
}

public class ResolveNonConformityResponse
{
    public Guid NonConformityId { get; set; }
    public DateTime ResolvedAt { get; set; }
    public string ResolutionDetails { get; set; } = string.Empty;
}
```

## InputPort / OutputPort para Resolución
```csharp
public interface IResolveNonConformityInputPort
{
    Task HandleAsync(ResolveNonConformityRequest request);
}

public interface IResolveNonConformityOutputPort
{
    Task HandleAsync(ResolveNonConformityResponse response);
}
```

## Interactor para Resolución
El interactor gestionará la lógica de resolución de la no conformidad, actualizando su estado y registrando los detalles de la resolución.

```csharp
public class ResolveNonConformityInteractor : IResolveNonConformityInputPort
{
    private readonly INonConformityRepository repository;
    private readonly IResolveNonConformityOutputPort outputPort;

    public ResolveNonConformityInteractor(
        INonConformityRepository repository,
        IResolveNonConformityOutputPort outputPort)
    {
        this.repository = repository;
        this.outputPort = outputPort;
    }

    public async Task HandleAsync(ResolveNonConformityRequest request)
    {
        var nonConformity = await repository.GetByIdAsync(request.NonConformityId);

        if (nonConformity == null || nonConformity.Status == "Closed")
        {
            // Handle non-conformity not found or already resolved
            return;
        }

        nonConformity.Status = "Closed";
        nonConformity.ResolvedAt = DateTime.UtcNow;
        nonConformity.ResolutionDetails = request.ResolutionDetails;
        nonConformity.ResolvedBy = request.ResolvedBy;

        await repository.UpdateAsync(nonConformity);

        var response = new ResolveNonConformityResponse
        {
            NonConformityId = nonConformity.Id,
            ResolvedAt = nonConformity.ResolvedAt.Value,
            ResolutionDetails = nonConformity.ResolutionDetails
        };

        await outputPort.HandleAsync(response);
    }
}
```

## Presenter para Resolución
El presenter actualiza el ViewModel después de que el interactor haya resuelto la no conformidad.

```csharp
public class ResolveNonConformityPresenter : IResolveNonConformityOutputPort
{
    private readonly ResolveNonConformityViewModel viewModel;

    public ResolveNonConformityPresenter(ResolveNonConformityViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task HandleAsync(ResolveNonConformityResponse response)
    {
        viewModel.NonConformityId = response.NonConformityId;
        viewModel.ResolvedAt = response.ResolvedAt;
        viewModel.ResolutionDetails = response.ResolutionDetails;
        viewModel.Status = "Non-conformity resolved successfully";
        return Task.CompletedTask;
    }
}
```

## ViewModel para Resolución
El ViewModel mantiene el estado de la resolución, que se enlazará con la interfaz de usuario de Blazor.

```csharp
public class ResolveNonConformityViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private Guid nonConformityId;
    private DateTime resolvedAt;
    private string resolutionDetails = string.Empty;
    private string status = string.Empty;

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

    public DateTime ResolvedAt
    {
        get => resolvedAt;
        set
        {
            if (resolvedAt != value)
            {
                resolvedAt = value;
                NotifyPropertyChanged(nameof(ResolvedAt));
            }
        }
    }

    public string ResolutionDetails
    {
        get => resolutionDetails;
        set
        {
            if (resolutionDetails != value)
            {
                resolutionDetails = value;
                NotifyPropertyChanged(nameof(ResolutionDetails));
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

    private void NotifyPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```

## Componente Blazor para Resolución de No Conformidades
Ahora vamos a crear un formulario en Blazor para resolver una no conformidad, donde un usuario puede añadir los detalles de resolución.

```razor
@page "/resolve-nonconformity/{NonConformityId}"
@inject IResolveNonConformityInputPort ResolveNonConformityInputPort
@inject NavigationManager Navigation

@code {
    [Parameter] public Guid NonConformityId { get; set; }
    private ResolveNonConformityViewModel viewModel = new ResolveNonConformityViewModel();
    private ResolveNonConformityPresenter? presenter;

    protected override async Task OnInitializedAsync()
    {
        presenter = new ResolveNonConformityPresenter(viewModel);
        viewModel.NonConformityId = NonConformityId;
    }

    private async Task HandleSubmit()
    {
        ResolveNonConformityRequest request = new ResolveNonConformityRequest
        {
            NonConformityId = viewModel.NonConformityId,
            ResolutionDetails = viewModel.ResolutionDetails,
            ResolvedBy = "Admin" // This could be dynamic based on the current user
        };

        await ResolveNonConformityInputPort.HandleAsync(request);
        Navigation.NavigateTo("/nonconformity-confirmation");
    }
}

<div class="container">
    <h3 class="title is-4">Resolve Non-Conformity</h3>

    <div class="box">
        <div class="field">
            <label class="label">Resolution Details</label>
            <div class="control">
                <textarea class="textarea" @bind="viewModel.ResolutionDetails" placeholder="Details of the resolution"></textarea>
            </div>
        </div>

        <button class="button is-primary" @onclick="HandleSubmit">Resolve</button>
    </div>

    @if (!string.IsNullOrEmpty(viewModel.Status))
    {
        <div class="notification is-success">
            @viewModel.Status
        </div>
    }
</div>
```

# Resumen de resolución de No Conformidad:
- Entidad NonConformity: Se amplió con detalles de resolución.
- Caso de Uso ResolveNonConformity: Actualiza el estado de la no conformidad y registra los detalles de la resolución.
- Presenter ResolveNonConformityPresenter: Actualiza el ViewModel tras la resolución.
- ViewModel ResolveNonConformityViewModel: Mantiene el estado de la resolución y se enlaza con la UI.
- Componente Blazor ResolveNonConformity.razor: Permite al usuario registrar los detalles de la resolución de una no conformidad.
