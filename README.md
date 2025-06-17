# ISO 9001 Microservice

Este microservicio implementa funcionalidades orientadas al cumplimiento de la norma **ISO 9001:2015** en un sistema de ventas online multitenant. Su diseño está basado en **Clean Architecture** (Uncle Bob) y está pensado para integrarse fácilmente con otras APIs del ecosistema.

## Características

- Registro de **no conformidades**.
- Gestión de **resoluciones de no conformidades**.
- Captura y análisis de **feedback del cliente**.
- Seguimiento de acciones del cliente/pedido para auditorías.
- **Panel de calidad** para visualización de KPIs.
- Generación de **informes de auditoría** en HTML.
- Totalmente **multitenant**, utilizando `X-Reference` en cabeceras HTTP para el `companyId`.

## Arquitectura

- **Dominio**: Entidades ricas y casos de uso desacoplados.
- **Aplicación**: Interactores, presentadores y controladores.
- **Infraestructura**: Implementaciones de repositorios.
- **UI**: Blazor WebAssembly con patrón **MVVM** (Model-View-ViewModel).
- **API**: Minimal API opcional o Controller-based API.

## Endpoints

Algunos endpoints disponibles:

| Método | Ruta | Descripción |
|--------|------|-------------|
| `POST` | `/api/nonconformity` | Registrar no conformidad |
| `POST` | `/api/nonconformity/resolve` | Registrar resolución |
| `POST` | `/api/feedback` | Enviar feedback de cliente |
| `GET`  | `/api/audit-events/{orderId}` | Obtener auditoría de pedido |
| `GET`  | `/api/quality/dashboard` | KPI de calidad |
| `GET`  | `/api/audit/report/{companyId}` | Informe auditoría HTML |

## Requisitos

- .NET 9
- Blazor WebAssembly
- SQL Server o PostgreSQL
- Mailer API configurada para feedbacks

## Integración

Solo necesitas enviar los datos a esta API desde los microservicios que correspondan:

- Desde el microservicio de Pedidos: registrar acción de `OrderCreated`.
- Desde el microservicio de Pagos: registrar acción `PaymentReceived`.
- Desde la UI (Blazor): envío de feedback, visualización de auditoría y KPI.

## Licencia

MIT License.