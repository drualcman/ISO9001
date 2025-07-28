# Contexto
- Sistema que puede hacer una venta de un producto y/o servicio. Por lo que cuando es un servicio hay una accion de booking.
- El usuario hace un pedido online o un booking (o la combinacion de ambos) y realiza el pago.
- La página de checkout solicita los datos del cliente, muestra los productos/servicios y realiza el pago.
- Mi id inicial para todo es la sesion se usuario, que luego ya se asigna a una orden, por ejemplo, el pago se realiza antes de tener la orden, por lo que el id es el de la sesion y luego se asigna el id del pedido (invoiceid)
- Finalmente, si el usuario lo que ordeno era un servicio de booking, hasta que el usuario no visita la tiene para que le den, por ejemplo, un masaje, no se puede solicitar un feedback, o se podria, por ejemplo, solocitar el feedback de como fue el proceso de pedido y luego otro de como fue el masaje.
- De echo, el tema del pago podria ser en efectivo cuando el usuario llega a lamtienda, pero en el checkout realmente se asigna como cash, pero no es realmente pagado hasta que llega a la tienda.
- Como seria todo el proceso del 9001 en este caso, creo yo, tan poco habitual?

# Propuesta

Vamos a descomponer cómo aplicar el sistema de gestión de calidad (SGC) ISO 9001 en tu flujo real, paso a paso. Lo haré pensando tanto en los procesos como en su implementación técnica con Clean Architecture y Blazor.

## Resumen del flujo real:
- Usuario anónimo o registrado accede al sistema → se le asigna un ID de sesión.
- Elige productos y/o servicios (como un masaje).
- Realiza el checkout (elige método de pago, ingresa datos personales).
- El pago puede ser inmediato (online) o en tienda (cash).
- Si hay booking, se espera a que asista.
- Se pueden recoger diferentes tipos de feedback.

Todo puede generar trazabilidad (auditoría) e incidencias (no conformidades).

# Aplicación del ISO 9001 en este flujo
## Contexto organizacional y planificación
Identificar que existen dos tipos de flujo: venta directa y servicio reservado (booking).

Registrar expectativas del cliente en base a tipo de producto o servicio (esto se hace desde el catálogo).

## Procesos clave en tu sistema
Aquí van los procesos ISO 9001 implementables y cómo encajan en tu sistema:

**Proceso ISO**										**Implementación técnica**										**Cuándo ocurre**
Registro de orden									PlaceOrderInteractor + Order Entity								Al terminar checkout
Validación de pago									RegisterPaymentInteractor										Al elegir método de pago y confirmar
Confirmación de servicio (booking)					ConfirmBookingInteractor										Cuando el usuario asiste a la tienda
Auditoría de eventos								OrderAuditTrail Repository + Eventos							En cada paso: creación, pago, asistencia, etc.
Feedback del cliente								RequestFeedbackInteractor y CustomerFeedback					Al finalizar el pedido o servicio
Gestión de no conformidades							RegisterNonConformityInteractor									Cuando un cliente reporta un problema
Resolución de no conformidades						ResolveNonConformityInteractor									Por parte de soporte
Análisis de feedback								FeedbackAnalysisInteractor										Para detección de patrones o errores
Auditoría interna									GenerateAuditReportInteractor									Acceso interno por staff para evaluar calidad
Dashboard de calidad								QualityDashboardViewModel en Blazor								Para visualizar estado global del sistema

## Adaptaciones ISO específicas para tu caso
### Flujo de venta con pago en tienda
El RegisterPayment permite registrar la intención (efectivo en tienda) y más tarde el ConfirmPayment.

Debe marcarse como “pendiente de pago” hasta que sea verificado en tienda.

### Booking y seguimiento
Se puede tener una entidad BookingAttendance que indique si el cliente asistió.

El feedback puede dividirse:

- Feedback de la compra online.
- Feedback del servicio prestado (tras asistencia).

### Uso de sesión como identificador previo
Los logs de auditoría deben usar el ID de sesión como identificador hasta que se genere una orden.

Luego se debe relacionar la sesión con el OrderId para unir todos los eventos.

## ¿Dónde se manifiesta ISO 9001 aquí?
Evidencia documental automática: cada paso del proceso queda registrado.

Medición de satisfacción del cliente: sistema de feedback.

Trazabilidad total: todo evento auditable.

Mejora continua: mediante análisis del feedback y gestión de no conformidades.

Transparencia y control: gracias al dashboard y reportes.


