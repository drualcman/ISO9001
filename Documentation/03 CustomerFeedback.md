# CustomerFeedback
Este proceso puede estar vinculado a la finalización del pedido (PlaceOrder) y tener efectos como:

- Mostrar un formulario de satisfacción.
- Enviar un correo solicitando feedback.
- Guardar el feedback para análisis futuro (otro principio clave de ISO 9001).

## Entidad: CustomerFeedback
```csharp
public class CustomerFeedback
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int Rating { get; set; } // 1 to 5
    public string Comments { get; set; }
    public DateTime SubmittedAt { get; set; }
}
```

## Request / Response
```csharp
public class SubmitFeedbackRequest
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
}

public class SubmitFeedbackResponse
{
    public int FeedbackId { get; set; }
}
```

## InputPort / OutputPort
```csharp
public interface ISubmitFeedbackInputPort
{
    Task HandleAsync(SubmitFeedbackRequest request);
}

public interface ISubmitFeedbackOutputPort
{
    Task HandleAsync(SubmitFeedbackResponse response);
    Task Invalid(string reason);
}
```

## Interactor: SubmitFeedbackInteractor
```csharp
public class SubmitFeedbackInteractor : ISubmitFeedbackInputPort
{
    private readonly ICustomerFeedbackRepository feedbackRepository;
    private readonly ISubmitFeedbackOutputPort outputPort;

    public SubmitFeedbackInteractor(
        ICustomerFeedbackRepository feedbackRepository,
        ISubmitFeedbackOutputPort outputPort)
    {
        this.feedbackRepository = feedbackRepository;
        this.outputPort = outputPort;
    }

    public async Task HandleAsync(SubmitFeedbackRequest request)
    {
        if (request.Rating < 1 || request.Rating > 5)
        {
            await outputPort.Invalid("Rating must be between 1 and 5.");
            return;
        }

        CustomerFeedback feedback = new CustomerFeedback
        {
            OrderId = request.OrderId,
            CustomerId = request.CustomerId,
            Rating = request.Rating,
            Comments = request.Comments,
            SubmittedAt = DateTime.UtcNow
        };

        await feedbackRepository.SaveAsync(feedback);

        SubmitFeedbackResponse response = new SubmitFeedbackResponse
        {
            FeedbackId = feedback.Id
        };

        await outputPort.HandleAsync(response);
    }
}
```

## Repositorio: ICustomerFeedbackRepository y su implementación
Interfaz (en la capa de dominio):
```csharp
public interface ICustomerFeedbackRepository
{
    Task SaveAsync(CustomerFeedback feedback);
    Task<List<CustomerFeedback>> GetByCustomerIdAsync(int customerId);
    Task<List<CustomerFeedback>> GetByRatingAsync(int rating);
}
```
Nota: Añadimos algunos métodos típicos de consulta para futuras vistas de estadísticas.

### Implementación temporal en memoria (puede adaptarse luego a EF):
```csharp
public class InMemoryCustomerFeedbackRepository : ICustomerFeedbackRepository
{
    private readonly List<CustomerFeedback> feedbackList = new List<CustomerFeedback>();
    private int counter = 1;

    public Task SaveAsync(CustomerFeedback feedback)
    {
        feedback.Id = counter;
        counter += 1;
        feedbackList.Add(feedback);
        return Task.CompletedTask;
    }

    public Task<List<CustomerFeedback>> GetByCustomerIdAsync(int customerId)
    {
        List<CustomerFeedback> result = feedbackList
            .Where(f => f.CustomerId == customerId)
            .ToList();

        return Task.FromResult(result);
    }

    public Task<List<CustomerFeedback>> GetByRatingAsync(int rating)
    {
        List<CustomerFeedback> result = feedbackList
            .Where(f => f.Rating == rating)
            .ToList();

        return Task.FromResult(result);
    }
}
```

## Extender el flujo del caso de uso PlaceOrder para que, una vez se complete el pedido, el sistema:

Registre el pedido normalmente.

Envíe un correo al cliente solicitando su feedback con un enlace al formulario Blazor.

## Servicio de Correo (puede usarse una abstracción)
Interfaz: ICustomerFeedbackNotificationService
```csharp
public interface ICustomerFeedbackNotificationService
{
    Task SendFeedbackRequestAsync(string customerEmail, int orderId);
}
``
Implementación simulada (para pruebas):
```csharp
public class FakeCustomerFeedbackNotificationService : ICustomerFeedbackNotificationService
{
    public Task SendFeedbackRequestAsync(string customerEmail, int orderId)
    {
        // In production, integrate with SMTP or SendGrid
        Console.WriteLine($"[EMAIL] Sent feedback link to {customerEmail} for Order #{orderId}");
        return Task.CompletedTask;
    }
}
```

## Extender PlaceOrderInteractor
Nuevas dependencias:
ICustomerFeedbackNotificationService

```ICustomerRepository``` para obtener el email

Ejemplo de PlaceOrderInteractor:
```csharp
public class PlaceOrderInteractor : IPlaceOrderInputPort
{
    private readonly IOrderRepository orderRepository;
    private readonly ICustomerRepository customerRepository;
    private readonly ICustomerFeedbackNotificationService feedbackNotifier;
    private readonly IPlaceOrderOutputPort outputPort;

    public PlaceOrderInteractor(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        ICustomerFeedbackNotificationService feedbackNotifier,
        IPlaceOrderOutputPort outputPort)
    {
        this.orderRepository = orderRepository;
        this.customerRepository = customerRepository;
        this.feedbackNotifier = feedbackNotifier;
        this.outputPort = outputPort;
    }

    public async Task HandleAsync(PlaceOrderRequest request)
    {
        Order order = new Order
        {
            CustomerId = request.CustomerId,
            Products = request.Products,
            CreatedAt = DateTime.UtcNow,
            Status = "Placed"
        };

        await orderRepository.SaveAsync(order);

        Customer? customer = await customerRepository.GetByIdAsync(request.CustomerId);
        if (customer != null)
        {
            await feedbackNotifier.SendFeedbackRequestAsync(customer.Email, order.Id);
        }

        PlaceOrderResponse response = new PlaceOrderResponse
        {
            OrderId = order.Id,
            Status = order.Status
        };

        await outputPort.HandleAsync(response);
    }
}
```

## Link al formulario de feedback
Supón que el enlace apunta a algo como:

```arduino
https://miapp.com/submit-feedback?orderId=123&customerId=456
```
Tu componente Blazor de SubmitFeedback.razor podrá leer esos parámetros y precargar el formulario con ellos.

## Formulario de feedback en Blazor, siguiendo el patrón MVVM. Cubriremos:

- ViewModel (lógica del componente)
- Presenter (transforma el output del interactor)
- Componente Blazor (SubmitFeedback.razor)

### ViewModel: SubmitFeedbackViewModel
```csharp
public class SubmitFeedbackViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private int rating;
    private string comments = string.Empty;
    private string message = string.Empty;
    private bool isSubmitted;

    public int Rating
    {
        get => rating;
        set
        {
            if (rating != value)
            {
                rating = value;
                NotifyPropertyChanged(nameof(Rating));
            }
        }
    }

    public string Comments
    {
        get => comments;
        set
        {
            if (comments != value)
            {
                comments = value;
                NotifyPropertyChanged(nameof(Comments));
            }
        }
    }

    public string Message
    {
        get => message;
        set
        {
            if (message != value)
            {
                message = value;
                NotifyPropertyChanged(nameof(Message));
            }
        }
    }

    public bool IsSubmitted
    {
        get => isSubmitted;
        set
        {
            if (isSubmitted != value)
            {
                isSubmitted = value;
                NotifyPropertyChanged(nameof(IsSubmitted));
            }
        }
    }

    private void NotifyPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```
### Presenter: SubmitFeedbackPresenter
```csharp
public class SubmitFeedbackPresenter : ISubmitFeedbackOutputPort
{
    private readonly SubmitFeedbackViewModel viewModel;

    public SubmitFeedbackPresenter(SubmitFeedbackViewModel viewModel)
    {
        this.viewModel = viewModel;
    }

    public Task HandleAsync(SubmitFeedbackResponse response)
    {
        viewModel.Message = $"Thank you for your feedback! Ref: #{response.FeedbackId}";
        viewModel.IsSubmitted = true;
        return Task.CompletedTask;
    }

    public Task Invalid(string reason)
    {
        viewModel.Message = $"Error: {reason}";
        return Task.CompletedTask;
    }
}
```

### Componente Blazor: SubmitFeedback.razor
```razor
@page "/submit-feedback"
@inject NavigationManager Navigation
@inject ISubmitFeedbackInputPort SubmitFeedbackInputPort

@code {
    private SubmitFeedbackViewModel viewModel = new SubmitFeedbackViewModel();
    private SubmitFeedbackPresenter? presenter;
    private int customerId;
    private int orderId;

    protected override void OnInitialized()
    {
        presenter = new SubmitFeedbackPresenter(viewModel);

        Dictionary<string, string> query = Microsoft.AspNetCore.WebUtilities
            .QueryHelpers.ParseQuery(new Uri(Navigation.Uri).Query)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());

        if (query.TryGetValue("orderId", out string orderStr) &&
            query.TryGetValue("customerId", out string customerStr))
        {
            orderId = int.Parse(orderStr);
            customerId = int.Parse(customerStr);
        }
    }

    private async Task SubmitAsync()
    {
        SubmitFeedbackRequest request = new SubmitFeedbackRequest
        {
            OrderId = orderId,
            CustomerId = customerId,
            Rating = viewModel.Rating,
            Comments = viewModel.Comments
        };

        await SubmitFeedbackInputPort.HandleAsync(request);
    }
}

@if (!viewModel.IsSubmitted)
{
    <div class="box">
        <h3 class="title is-4">Rate your purchase</h3>

        <div class="field">
            <label class="label">Rating (1-5)</label>
            <div class="control">
                <input class="input" type="number" min="1" max="5" @bind="viewModel.Rating" />
            </div>
        </div>

        <div class="field">
            <label class="label">Comments</label>
            <div class="control">
                <textarea class="textarea" @bind="viewModel.Comments"></textarea>
            </div>
        </div>

        <div class="control">
            <button class="button is-primary" @onclick="SubmitAsync">Submit Feedback</button>
        </div>
    </div>
}
<p class="has-text-success">@viewModel.Message</p>
```

# Con esto, cierras el ciclo Plan → Do → Check → Act de ISO 9001 en el flujo de venta:

- Plan: Proceso de pedidos bien definido y documentado.
- Do: Registro de órdenes y cobros.
- Check: Solicitud y almacenamiento de feedback del cliente.
