# Generador de informe de auditoría
Lo primero es definir qué información debe contener el informe y de dónde se obtendrá esta información.

## Generador de Informe de Auditoría
El informe de auditoría debe contener una serie de eventos clave que se han registrado a lo largo del ciclo de vida de un pedido y la interacción con el sistema. Estos eventos son vitales para asegurar la trazabilidad, uno de los requisitos clave de ISO 9001.

Información que debe generar el informe:
- ID del Pedido: Identificador único del pedido que será auditado.
- Fecha de Creación del Pedido: Cuando el pedido fue creado en el sistema.
- Estado del Pedido: Estado actual del pedido (ej., "Pendiente", "En Proceso", "Completado").

Transacciones de Pago:

- Fecha de pago
- Monto pagado
- Estado del pago (ej., "Completado", "Fallido").
- Eventos de No Conformidad:
- Fecha en la que se reportó la no conformidad.
- Descripción de la no conformidad.
- Estado de la no conformidad (ej., "Pendiente", "Resuelta").
- Feedback del Cliente:
- Fecha del feedback.
- Calificación otorgada (por ejemplo, de 1 a 5).
- Comentarios adicionales.

Resoluciones de No Conformidad:

- Fecha de resolución de la no conformidad.
- Descripción de las acciones tomadas.
- Resultado de la resolución (ej., "Resuelto", "No resuelto").
- Historial de Cambios de Estado del Pedido: Registro de cualquier cambio en el estado del pedido (desde "Pendiente" hasta "Completado").
- Incidentes: Si el pedido tiene incidencias o problemas reportados, deben estar reflejados en el informe.
- Historial de Comunicaciones con el Cliente: Emails enviados o cualquier otra comunicación importante.

## Fuentes de Datos para el Informe:
- Pedidos (Orders): Los pedidos serán la base para generar el informe, ya que se registra el ID del pedido, su creación, su estado y su evolución.
- Transacciones de Pago (Payments): Los pagos están registrados y asociados a los pedidos, y deben incluirse para asegurar la trazabilidad de los cobros.
- No Conformidades (Non-Conformities): Los eventos de no conformidad deben ser rastreados a lo largo del ciclo del pedido. Pueden ser reportados en diferentes momentos y deben reflejarse en el informe.
- Feedback del Cliente (Customer Feedback): El feedback recibido por parte del cliente también es un dato clave para auditoría, ya que proporciona información sobre la calidad del servicio.
- Eventos de Cambio de Estado: Cada vez que el estado de un pedido cambie (por ejemplo, de "Pendiente" a "Completado"), esto debe registrarse como un evento de auditoría.
- Comunicaciones con el Cliente: Las comunicaciones, como los correos electrónicos o mensajes, deben quedar registradas con sus fechas y detalles.

## Generación del Informe de Auditoría - Flujo
- Solicitud de Informe: El sistema recibe una solicitud para generar un informe de auditoría de un pedido específico.
- Recopilación de Datos: El sistema recopila los datos de los repositorios de Pedidos, Pagos, No Conformidades, Feedbacks, Incidentes y Comunicaciones.
- Generación del Informe: Los datos recopilados se organizan en un informe estructurado, que puede ser generado en formatos como PDF o HTML.

## Implementación del Generador de Informe de Auditoría
A continuación, mostramos cómo podrías empezar a implementar el servicio para generar el informe de auditoría en C#.

### Entidad de Auditoría
Primero, definimos una clase que modela la estructura del informe.

```csharp
public class AuditReport
{
    public string OrderId { get; set; }
    public DateTime OrderCreationDate { get; set; }
    public string OrderStatus { get; set; }
    public List<PaymentTransaction> Payments { get; set; } = new();
    public List<NonConformity> NonConformities { get; set; } = new();
    public List<CustomerFeedback> Feedbacks { get; set; } = new();
    public List<string> StateChanges { get; set; } = new();
    public List<Communication> Communications { get; set; } = new();
    public List<Incident> Incidents { get; set; } = new();
}
```

### Servicio de Generación de Informe de Auditoría
El servicio de generación de informes recibirá el OrderId y buscará toda la información necesaria.

```csharp
public class AuditReportService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly INonConformityRepository _nonConformityRepository;
    private readonly ICustomerFeedbackRepository _customerFeedbackRepository;
    private readonly IIncidentRepository _incidentRepository;
    private readonly ICommunicationRepository _communicationRepository;

    public AuditReportService(
        IOrderRepository orderRepository,
        IPaymentRepository paymentRepository,
        INonConformityRepository nonConformityRepository,
        ICustomerFeedbackRepository customerFeedbackRepository,
        IIncidentRepository incidentRepository,
        ICommunicationRepository communicationRepository)
    {
        _orderRepository = orderRepository;
        _paymentRepository = paymentRepository;
        _nonConformityRepository = nonConformityRepository;
        _customerFeedbackRepository = customerFeedbackRepository;
        _incidentRepository = incidentRepository;
        _communicationRepository = communicationRepository;
    }

    public async Task<AuditReport> GenerateReportAsync(string orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        var payments = await _paymentRepository.GetByOrderIdAsync(orderId);
        var nonConformities = await _nonConformityRepository.GetByOrderIdAsync(orderId);
        var feedbacks = await _customerFeedbackRepository.GetByOrderIdAsync(orderId);
        var incidents = await _incidentRepository.GetByOrderIdAsync(orderId);
        var communications = await _communicationRepository.GetByOrderIdAsync(orderId);

        var auditReport = new AuditReport
        {
            OrderId = orderId,
            OrderCreationDate = order.CreatedAt,
            OrderStatus = order.Status,
            Payments = payments.ToList(),
            NonConformities = nonConformities.ToList(),
            Feedbacks = feedbacks.ToList(),
            Incidents = incidents.ToList(),
            Communications = communications.ToList(),
            StateChanges = GetOrderStateChanges(orderId) // You can implement this method to track state changes.
        };

        return auditReport;
    }

    private List<string> GetOrderStateChanges(string orderId)
    {
        // This method should track all changes of order status
        return new List<string>
        {
            "Created: 2025-04-01",
            "Paid: 2025-04-05",
            "Shipped: 2025-04-06"
        };
    }
}
```
## Conclusión
Este servicio de auditoría recopila los datos de los diferentes repositorios y genera un informe completo para ser utilizado por los auditores o el sistema de gestión de calidad. El informe contiene todos los eventos clave relacionados con un pedido y su trazabilidad en el sistema.

# Crear la Página Blazor para Mostrar el Informe
Primero, definimos el componente Blazor para mostrar el informe en formato HTML. Este componente tomará el AuditReport generado y lo mostrará en la interfaz de usuario.

## Componente Blazor AuditReportPage.razor
```razor
@page "/audit-report/{OrderId}"
@inject AuditReportService AuditReportService

@using YourNamespace.Models
@using System.Threading.Tasks

<h3>Audit Report for Order @OrderId</h3>

@if (auditReport == null)
{
    <p>Loading report...</p>
}
else
{
    <div class="audit-report">
        <h4>Order Information</h4>
        <table class="table is-bordered">
            <tr>
                <th>Order ID</th>
                <td>@auditReport.OrderId</td>
            </tr>
            <tr>
                <th>Order Creation Date</th>
                <td>@auditReport.OrderCreationDate</td>
            </tr>
            <tr>
                <th>Order Status</th>
                <td>@auditReport.OrderStatus</td>
            </tr>
        </table>

        <h4>Payment Transactions</h4>
        @if (auditReport.Payments.Any())
        {
            <table class="table is-bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Amount</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var payment in auditReport.Payments)
                    {
                        <tr>
                            <td>@payment.Date</td>
                            <td>@payment.Amount</td>
                            <td>@payment.Status</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
        else
        {
            <p>No payment transactions found.</p>
        }

        <h4>Non-Conformities</h4>
        @if (auditReport.NonConformities.Any())
        {
            <table class="table is-bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Description</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var nonConformity in auditReport.NonConformities)
                    {
                        <tr>
                            <td>@nonConformity.Date</td>
                            <td>@nonConformity.Description</td>
                            <td>@nonConformity.Status</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
        else
        {
            <p>No non-conformities reported.</p>
        }

        <h4>Customer Feedback</h4>
        @if (auditReport.Feedbacks.Any())
        {
            <table class="table is-bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Rating</th>
                        <th>Comments</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var feedback in auditReport.Feedbacks)
                    {
                        <tr>
                            <td>@feedback.Date</td>
                            <td>@feedback.Rating</td>
                            <td>@feedback.Comments</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
        else
        {
            <p>No customer feedback found.</p>
        }

        <h4>Incident History</h4>
        @if (auditReport.Incidents.Any())
        {
            <table class="table is-bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Description</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var incident in auditReport.Incidents)
                    {
                        <tr>
                            <td>@incident.Date</td>
                            <td>@incident.Description</td>
                            <td>@incident.Status</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
        else
        {
            <p>No incidents reported.</p>
        }

        <h4>State Changes</h4>
        @if (auditReport.StateChanges.Any())
        {
            <ul>
                @foreach (var change in auditReport.StateChanges)
                {
                    <li>@change</li>
                }
            </ul>
        }
        else
        {
            <p>No state changes recorded.</p>
        }

        <h4>Communications</h4>
        @if (auditReport.Communications.Any())
        {
            <table class="table is-bordered">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Type</th>
                        <th>Details</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var communication in auditReport.Communications)
                    {
                        <tr>
                            <td>@communication.Date</td>
                            <td>@communication.Type</td>
                            <td>@communication.Details</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
        else
        {
            <p>No communications recorded.</p>
        }
    </div>
}

@code {
    [Parameter]
    public string OrderId { get; set; }

    private AuditReport auditReport;

    protected override async Task OnInitializedAsync()
    {
        // Fetch the audit report data
        auditReport = await AuditReportService.GenerateReportAsync(OrderId);
    }
}
```
### Explicación del Código:
Inyección de Dependencias: Usamos la inyección de dependencias (AuditReportService) para obtener los datos del informe de auditoría. El servicio se encarga de recuperar todos los eventos y detalles relacionados con el pedido.

Parámetro de la URL (OrderId): El OrderId se obtiene desde la URL, y se pasa al componente como parámetro. Esto permite que cada vez que un usuario navegue a un OrderId específico, el informe correspondiente se cargue.

Carga de Datos del Informe: En el método OnInitializedAsync(), el componente llama al servicio AuditReportService para generar el informe de auditoría para el pedido indicado por OrderId.

Renderizado Condicional: 
- Si el informe está disponible (auditReport != null), se muestra la información en tablas HTML. Cada sección de datos (como pagos, retroalimentación, no conformidades, etc.) se presenta en una tabla separada.
- Si no hay datos (por ejemplo, no hay pagos o retroalimentación), se muestra un mensaje informando de ello.

Estilo de Bulma: Se utiliza Bulma para darle formato a las tablas y otros elementos. Las clases de Bulma como table, is-bordered, etc., se usan para dar estilo a las tablas de manera sencilla.

## Hacer que Blazor Use este Componente
Este componente será accesible en la ruta /audit-report/{OrderId}. Cuando accedas a esa URL, el componente tomará el OrderId de la URL y cargará los datos correspondientes.

Ejemplo de URL:
```bash
/audit-report/12345
```
Esto mostrará el informe de auditoría para el pedido con ID 12345.

### Conclusión
Este componente en Blazor permite generar y visualizar el informe de auditoría de manera estructurada. La información se organiza en secciones, y el formato HTML garantiza que sea fácilmente legible y accesible para los auditores o cualquier usuario autorizado que necesite revisar la trazabilidad del pedido.