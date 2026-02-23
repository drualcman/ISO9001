# ISO 9001 Microservice

This microservice implements features aimed at compliance with the **ISO 9001:2015** standard in a multitenant online sales system. Its design is based on **Clean Architecture** (Uncle Bob) and is intended to integrate easily with other APIs in the ecosystem.

## Features

- **Nonconformity** registration.
- **Nonconformity resolution** management.
- Customer **feedback capture and analysis**.
- Tracking of customer/order actions for auditing purposes.
- **Quality dashboard** for KPI visualization.
- Generation of **audit reports** in HTML.
- Fully **multitenant**, using `X-Reference` in HTTP headers for the `companyId`.

## Architecture

- **Domain**: Rich entities and decoupled use cases.
- **Application**: Interactors, presenters, and controllers.
- **Infrastructure**: Repository implementations.
- **UI**: Blazor WebAssembly using the **MVVM** (Model-View-ViewModel) pattern.
- **API**: Optional Minimal API or Controller-based API.

## Endpoints

Some available endpoints:

| Method | Route | Description |
|--------|--------|-------------|
| `POST` | `/api/nonconformity` | Register nonconformity |
| `POST` | `/api/nonconformity/resolve` | Register resolution |
| `POST` | `/api/feedback` | Send customer feedback |
| `GET`  | `/api/audit-events/{orderId}` | Get order audit events |
| `GET`  | `/api/quality/dashboard` | Quality KPIs |
| `GET`  | `/api/audit/report/{companyId}` | HTML audit report |

## Requirements

- .NET 8, 9, or 10
- Blazor WebAssembly
- SQL Server or PostgreSQL
- Mailer API configured for feedback processing

## Integration

You only need to send data to this API from the corresponding microservices:

- From the Orders microservice: register the `OrderCreated` action.
- From the Payments microservice: register the `PaymentReceived` action.
- From the UI (Blazor): send feedback, view audit data and KPIs.

## License

MIT License.