# Ventajas de separar el ISO 9001 en un microservicio propio
- Responsabilidad única (SRP): Este microservicio solo se encarga de calidad y cumplimiento.
- Desacoplamiento: No contamina las otras APIs con lógica ISO que no les corresponde.
- Escalabilidad independiente: Puedes hacer evolucionar el sistema ISO (dashboards, BI, notificaciones, etc.) sin tocar el core.
- Trazabilidad centralizada: Recibe eventos desde distintos microservicios (carrito, pagos, bookings) para construir un registro completo.

## ¿Qué tendría este microservicio ISO?
Entidades
- AuditEvent (evento de auditoría)
- CustomerFeedback
- NonConformity
- NonConformityResolution
- AuditReport

## Endpoints API
- POST /audit/event → registrar evento (creación pedido, pago, booking…)
- POST /feedback → registrar feedback de cliente
- POST /non-conformity → registrar una no conformidad
- POST /non-conformity/{id}/resolve → resolver una no conformidad
- GET /dashboard → obtener KPIs de calidad
- GET /audit/report → obtener informe completo HTML o PDF
 
## Integración desde otras APIs
- La API de pagos hace POST /audit/event cuando se paga o falla un pago.
- La API del carrito hace POST /audit/event cuando se crea un pedido.
- La interfaz de Blazor hace POST /feedback al recibir la valoración del usuario.
- El personal de soporte usa una interfaz para consultar y resolver no conformidades.

## Tecnología y arquitectura
- Clean Architecture dentro del microservicio ISO, por supuesto.
- Event-driven o HTTP REST, según el nivel de acoplamiento que quieras.
- DB propia para no compartir almacenamiento con otros microservicios.

Posibilidad futura de añadir:
- Notificaciones por correo
- Power BI / exportación de datos
- Integración con certificadoras externas

# Casos de Uso Iniciales
En esta primera fase diseñaremos los siguientes casos de uso:

- Registrar evento de auditoría
- Registrar feedback del cliente
- Registrar no conformidad
- Resolver no conformidad