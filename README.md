# ISO 9001 Microservice

Este microservicio implementa funcionalidades orientadas al cumplimiento de la norma **ISO 9001:2015** en un sistema de ventas online multitenant. Su dise�o est� basado en **Clean Architecture** (Uncle Bob) y est� pensado para integrarse f�cilmente con otras APIs del ecosistema.

## Caracter�sticas

- Registro de **no conformidades**.
- Gesti�n de **resoluciones de no conformidades**.
- Captura y an�lisis de **feedback del cliente**.
- Seguimiento de acciones del cliente/pedido para auditor�as.
- **Panel de calidad** para visualizaci�n de KPIs.
- Generaci�n de **informes de auditor�a** en HTML.
- Totalmente **multitenant**, utilizando `X-Reference` en cabeceras HTTP para el `companyId`.

## Arquitectura

- **Dominio**: Entidades ricas y casos de uso desacoplados.
- **Aplicaci�n**: Interactores, presentadores y controladores.
- **Infraestructura**: Implementaciones de repositorios.
- **UI**: Blazor WebAssembly con patr�n **MVVM** (Model-View-ViewModel).
- **API**: Minimal API opcional o Controller-based API.

## Endpoints

Algunos endpoints disponibles:

| M�todo | Ruta | Descripci�n |
|--------|------|-------------|
| `POST` | `/api/nonconformity` | Registrar no conformidad |
| `POST` | `/api/nonconformity/resolve` | Registrar resoluci�n |
| `POST` | `/api/feedback` | Enviar feedback de cliente |
| `GET`  | `/api/audit-events/{orderId}` | Obtener auditor�a de pedido |
| `GET`  | `/api/quality/dashboard` | KPI de calidad |
| `GET`  | `/api/audit/report/{companyId}` | Informe auditor�a HTML |

## Requisitos

- .NET 9
- Blazor WebAssembly
- SQL Server o PostgreSQL
- Mailer API configurada para feedbacks

## Integraci�n

Solo necesitas enviar los datos a esta API desde los microservicios que correspondan:

- Desde el microservicio de Pedidos: registrar acci�n de `OrderCreated`.
- Desde el microservicio de Pagos: registrar acci�n `PaymentReceived`.
- Desde la UI (Blazor): env�o de feedback, visualizaci�n de auditor�a y KPI.

## Licencia

MIT License.