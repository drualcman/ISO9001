# Entidad: AuditLog
La entidad AuditLog almacenará los registros de auditoría de los eventos importantes (por ejemplo, realizar un pedido). Este registro debería incluir:

EventType: El tipo de evento (ej. "PlaceOrder", "PaymentFailed").

Timestamp: La fecha y hora del evento.

UserId: El usuario que ha realizado la acción (ID del cliente o del administrador).

Data: Datos adicionales en formato JSON (por ejemplo, los detalles del pedido).

Result: El resultado del evento (ej. "Success", "Failure").

```csharp
public class AuditLog
{
    public int Id { get; set; }
    public string EventType { get; set; }
    public DateTime Timestamp { get; set; }
    public int UserId { get; set; }
    public string Data { get; set; }
    public string Result { get; set; }
}
```

# Repositorio: IAuditLogRepository
Ahora vamos a definir la interfaz para el repositorio de auditoría, que será responsable de guardar los registros.

```csharp
public interface IAuditLogRepository
{
    Task SaveAsync(AuditLog auditLog);
}
```
## Implementación del repositorio:
Puedes implementar este repositorio utilizando un sistema de base de datos o almacenamiento en archivos. A continuación te muestro un ejemplo simple utilizando una base de datos (suponiendo que estás utilizando Entity Framework u otra herramienta de persistencia).

```csharp
public class AuditLogRepository : IAuditLogRepository
{
    private readonly ApplicationDbContext _dbContext;

    public AuditLogRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveAsync(AuditLog auditLog)
    {
        await _dbContext.AuditLogs.AddAsync(auditLog);
        await _dbContext.SaveChangesAsync();
    }
}
```

# Caso de uso: LogAudit
El caso de uso LogAudit será responsable de crear el registro de auditoría. Lo vamos a integrar dentro del PlaceOrderInteractor para registrar el log después de que el pedido se haya realizado.

## Caso de uso LogAudit
```csharp
public class PlaceOrderInteractor : IPlaceOrderInputPort
{
    private readonly IPlaceOrderOutputPort outputPort;
    private readonly IOrderRepository orderRepository;
    private readonly IAuditLogRepository auditLogRepository;

    public PlaceOrderInteractor(
        IPlaceOrderOutputPort outputPort,
        IOrderRepository orderRepository,
        IAuditLogRepository auditLogRepository)
    {
        this.outputPort = outputPort;
        this.orderRepository = orderRepository;
        this.auditLogRepository = auditLogRepository;
    }

    public async Task HandleAsync(PlaceOrderRequest request)
    {
        // Lógica para procesar el pedido
        Order order = new Order
        {
            CustomerId = request.CustomerId,
            TotalAmount = CalculateTotalAmount(request.Items),
            OrderItems = request.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        // Guardamos el pedido
        await orderRepository.SaveAsync(order);

        // Creamos el log de auditoría
        AuditLog auditLog = new AuditLog
        {
            EventType = "PlaceOrder",
            Timestamp = DateTime.UtcNow,
            UserId = request.CustomerId,
            Data = JsonSerializer.Serialize(request),
            Result = "Success"
        };

        await auditLogRepository.SaveAsync(auditLog);

        // Enviamos el resultado al output port
        outputPort.Handle(new PlaceOrderResponse { OrderId = order.Id });
    }

    private decimal CalculateTotalAmount(IEnumerable<OrderItemRequest> items)
    {
        // Lógica para calcular el total
        return items.Sum(item => item.Quantity * 20); // Ejemplo simple
    }
}
```

# Integración en Blazor WebAssembly (UI)
Después de realizar un pedido, en el componente Blazor, podemos mostrar el mensaje de éxito, y si se ha guardado el log correctamente.

```razor
@page "/place-order"
@inject PlaceOrderVM ViewModel

<h3>Place Order</h3>

<!-- Formulario de pedido aquí -->

<button class="button is-primary" @onclick="PlaceOrder">Place Order</button>

@if (ViewModel.Result != null)
{
    <div class="notification is-success">
        <p>Order placed successfully!</p>
        <p>Order ID: @ViewModel.Result.OrderId</p>
    </div>
}

@code {
    private async Task PlaceOrder()
    {
        await ViewModel.PlaceOrderAsync();
    }
}
```