# ISO9001.Core

A .NET library that implements the core quality management use cases required by the **ISO 9001:2015** standard. It follows Clean Architecture principles and is designed for multi-tenant applications with full dependency-injection support.

---

## What is ISO 9001?

ISO 9001 is the world's most widely adopted quality management standard, published by the International Organization for Standardization (ISO). The **2015 revision** (ISO 9001:2015) defines requirements for a Quality Management System (QMS) that organizations must put in place to consistently provide products and services that meet customer and regulatory requirements, and to demonstrate a systematic approach to continual improvement.

The standard is structured around a process approach and risk-based thinking. Its key clauses that directly map to software traceability include:

| ISO 9001:2015 Clause | Requirement |
|---|---|
| **8.2** | Customer communication and determination of requirements |
| **8.7** | Control of nonconforming outputs |
| **9.1** | Monitoring, measurement, analysis, and evaluation |
| **9.1.2** | Customer satisfaction |
| **10.2** | Nonconformity and corrective action |
| **10.3** | Continual improvement |

In practice, a certified organization must be able to demonstrate, through documented evidence, that it:

- Tracks and logs what happens to products/orders at every step.
- Captures customer feedback and measures satisfaction.
- Records incidents when something goes wrong.
- Identifies nonconformities, investigates root causes, and closes them with corrective actions.
- Reviews quality KPIs and trends over time.

**ISO9001.Core** provides the building blocks to satisfy these requirements programmatically inside a .NET system.

---

## How the Library Maps to ISO 9001

| Feature | ISO 9001 requirement satisfied |
|---|---|
| **Audit Logs** | 8.1, 9.1 — traceability of operations performed on entities |
| **Incident Reports** | 8.7 — identification and control of nonconforming outputs in real time |
| **Non-Conformities** | 10.2 — formal nonconformity record + root cause + corrective action lifecycle |
| **Customer Feedback** | 9.1.2 — customer satisfaction monitoring with ratings and comments |
| **Quality Dashboard** | 9.1.3 — analysis and evaluation of quality data and KPIs |
| **Audit Reports** | 9.1 — documented evidence exportable as PDF/HTML |

---

## Target Frameworks

| Framework | Supported |
|---|---|
| .NET 8.0 | Yes |
| .NET 9.0 | Yes |
| .NET 10.0 | Yes |

---

## Installation

```shell
dotnet add package ISO9001.Core
```

---

## Architecture Overview

The library is built around **Clean Architecture** and **CQRS**:

```
ISO9001.Core
├── Entities/          — Domain entities and read models
├── Dtos/              — Immutable records used as command inputs
├── Requests/          — HTTP-level request models
├── Responses/         — Query results returned to callers
├── Interfaces/        — Public use-case contracts (commands & queries)
│   └── Internals/     — Data context contracts (implemented by your data layer)
├── Features/          — Use-case handlers and DI registration
└── Providers/         — Audit event aggregation providers
```

Your application must provide implementations of the **internal data context interfaces** (backed by EF Core, MongoDB, Cosmos DB, etc.). The core library is persistence-agnostic.

---

## Getting Started

### 1. Register services

Call the extension methods on `IServiceCollection` during application startup. Each module is independent — register only what you need.

```csharp
// Program.cs or Startup.cs
builder.Services.AddAuditLogCoreServices();
builder.Services.AddCustomerFeedbackCoreServices();
builder.Services.AddIncidentReportCoreServices();
builder.Services.AddNonConformityCoreServices();
builder.Services.AddQualityDashboardCoreServices();
builder.Services.AddAuditReportCoreServices();
builder.Services.AddAuditEventCoreServices();
```

### 2. Implement data context interfaces

The library defines internal interfaces that your infrastructure layer must implement. Wire them up in DI alongside the core services.

```csharp
// Example: EF Core implementation
builder.Services.AddScoped<IWritableAuditLogDataContext, AuditLogEfContext>();
builder.Services.AddScoped<IQueryableAuditLogDataContext, AuditLogEfContext>();

builder.Services.AddScoped<IWritableCustomerFeedbackDataContext, CustomerFeedbackEfContext>();
builder.Services.AddScoped<IQueryableCustomerFeedbackDataContext, CustomerFeedbackEfContext>();

builder.Services.AddScoped<IWritableIncidentReportDataContext, IncidentReportEfContext>();
builder.Services.AddScoped<IQueryableIncidentReportDataContext, IncidentReportEfContext>();

builder.Services.AddScoped<IWritableNonConformityDataContext, NonConformityEfContext>();
builder.Services.AddScoped<IQueryableNonConformityDataContext, NonConformityEfContext>();
```

All data context interfaces are in the `ISO9001.Core.Interfaces.Internals` namespace.

---

## Feature Reference

### Audit Logs

Audit logs record every significant action performed on a business entity (order, product, shipment, etc.), satisfying the traceability requirements of ISO 9001 clause 9.1.

#### Register an audit log entry

```csharp
public class OrderController : ControllerBase
{
    private readonly IRegisterAuditLog _registerAuditLog;

    public OrderController(IRegisterAuditLog registerAuditLog)
        => _registerAuditLog = registerAuditLog;

    [HttpPost("orders/{orderId}/ship")]
    public async Task<IActionResult> ShipOrder(string orderId)
    {
        // ... business logic ...

        await _registerAuditLog.HandleAsync(new AuditLogDto(
            EntityId:    orderId,
            CompanyId:   CurrentTenant.Id,
            Action:      "OrderShipped",
            PerformedBy: CurrentUser.Id,
            Timestamp:   DateTime.UtcNow,
            Details:     "Order dispatched to carrier",
            Data:        JsonSerializer.Serialize(shipmentInfo)
        ));

        return Ok();
    }
}
```

#### Query audit logs

```csharp
// All logs for a company, optionally filtered by date
IEnumerable<AuditLogResponse> logs = await _allAuditLogsQuery
    .HandleAsync(companyId, from: DateTime.UtcNow.AddDays(-30), end: null);

// Logs for a specific entity
IEnumerable<AuditLogResponse> orderLogs = await _auditLogsByEntityIdQuery
    .HandleAsync(companyId, entityId: orderId, from: null, end: null);

// Logs filtered by action type
IEnumerable<AuditLogResponse> shipLogs = await _auditLogsByActionQuery
    .HandleAsync(companyId, action: "OrderShipped", from: null, end: null);

// Single log by ID
AuditLogResponse entry = await _auditLogByIdQuery
    .HandleAsync(companyId, logId);
```

#### Generate an audit log report (PDF/HTML)

```csharp
ReportViewModel report = await _generateAuditLogReport
    .HandleAsync(companyId, entityId: orderId, from: null, end: null);
```

---

### Incident Reports

Incident reports capture real-time problems that occur during operations — a delivery failure, a production defect, a system error — providing the evidence trail required by ISO 9001 clause 8.7.

#### Register an incident

```csharp
await _registerIncidentReport.HandleAsync(new IncidentReportDto(
    CompanyId:       tenantId,
    EntityId:        orderId,
    ReportedAt:      DateTime.UtcNow,
    UserId:          userId,
    Description:     "Package arrived damaged",
    AffectedProcess: "Delivery",
    Severity:        "High",
    Data:            JsonSerializer.Serialize(damageInfo)
));
```

#### Query incident reports

```csharp
// All incidents for a company
IEnumerable<IncidentReportResponse> all = await _allIncidentReportsQuery
    .HandleAsync(companyId, from: null, end: null);

// Incidents linked to a specific order
IEnumerable<IncidentReportResponse> orderIncidents = await _incidentReportByEntityIdQuery
    .HandleAsync(companyId, entityId: orderId, from: null, end: null);

// Single incident by ID
IncidentReportResponse incident = await _getIncidentReportByIdInputPort
    .HandleAsync(companyId, incidentId);
```

---

### Non-Conformities

Non-conformities represent formal quality failures that require root cause analysis and corrective action, as required by ISO 9001 clause 10.2. A nonconformity has a lifecycle: it is opened, investigated, and eventually closed with documented corrective actions.

#### Open a non-conformity

```csharp
await _registerNonConformity.HandleAsync(new NonConformityDto(
    EntityId:        orderId,
    CompanyId:       tenantId,
    ReportedAt:      DateTime.UtcNow,
    ReportedBy:      userId,
    Description:     "Wrong product shipped to customer",
    AffectedProcess: "Fulfillment",
    Cause:           "Picker scanned incorrect SKU",
    Status:          "Open"
));
```

#### Add a corrective action detail

```csharp
await _registerNonConformityDetail.HandleAsync(new NonConformityCreateDetailDto(
    EntityId:    nonConformityId,
    CompanyId:   tenantId,
    ReportedAt:  DateTime.UtcNow,
    ReportedBy:  supervisorId,
    Description: "Retraining scheduled for warehouse picking team. New barcode scan verification enabled.",
    Status:      "Closed"
));
```

#### Query non-conformities

```csharp
// All nonconformities for a company
IEnumerable<NonConformityMaterResponse> all = await _allNonConformitiesQuery
    .HandleAsync(companyId, from: null, end: null);

// Filter by status
IEnumerable<NonConformityMaterResponse> open = await _nonConformityByStatusQuery
    .HandleAsync(companyId, status: "Open", from: null, end: null);

// Filter by affected process
IEnumerable<NonConformityMaterResponse> fulfillment = await _nonConformityByAffectedProcessQuery
    .HandleAsync(companyId, affectedProcess: "Fulfillment", from: null, end: null);

// Full detail for a specific entity (includes all corrective action details)
NonConformityResponse detail = await _nonConformityByEntityIdQuery
    .HandleAsync(companyId, entityId: orderId, from: null, end: null);
```

#### Generate non-conformity reports

```csharp
// Master list report
ReportViewModel masterReport = await _generateNonConformityMasterReport
    .HandleAsync(companyId, entityId: null, from: null, end: null);

// Detailed report for a single nonconformity
ReportViewModel detailReport = await _generateNonConformityDetailsReport
    .HandleAsync(companyId, nonConformityId: ncId, from: null, end: null);
```

---

### Customer Feedback

Customer feedback captures ratings and comments submitted by customers, satisfying the customer satisfaction monitoring requirement of ISO 9001 clause 9.1.2.

#### Register feedback

```csharp
await _registerCustomerFeedback.HandleAsync(new CustomerFeedbackDto(
    EntityId:   orderId,
    CompanyId:  tenantId,
    CustomerId: customerId,
    Rating:     4,
    Comments:   "Product was good but delivery was slow",
    ReportedAt: DateTime.UtcNow
));
```

#### Query feedback

```csharp
// All feedback for a company
IEnumerable<CustomerFeedbackResponse> all = await _allCustomerFeedbackQuery
    .HandleAsync(companyId, from: null, end: null);

// Feedback from a specific customer
IEnumerable<CustomerFeedbackResponse> byCustomer = await _customerFeedbackByCustomerIdQuery
    .HandleAsync(companyId, customerId, from: null, end: null);

// Feedback for a specific entity
IEnumerable<CustomerFeedbackResponse> byOrder = await _customerFeedbackByEntityIdQuery
    .HandleAsync(companyId, entityId: orderId, from: null, end: null);

// Feedback with a specific rating
IEnumerable<CustomerFeedbackResponse> lowRated = await _customerFeedbackByRatingQuery
    .HandleAsync(companyId, rating: 1, from: null, end: null);
```

#### Analyze feedback

The analysis query aggregates feedback into satisfaction insights, supporting the analysis
and evaluation requirement of ISO 9001 clause 9.1.3. Pass `entityId: null` to analyze the whole
company, or an entity id to scope the analysis to a single order/entity.

```csharp
AnalyzeFeedbackResponse analysis = await _analyzeCustomerFeedbackQuery
    .HandleAsync(companyId, entityId: null, from: null, end: null);
```

The `AnalyzeFeedbackResponse` contains:

| Property | Description |
|---|---|
| `AverageRating` | Mean satisfaction rating across the matched feedback |
| `TotalCount` | Number of feedback entries in the period |
| `RatingsByValue` | Dictionary mapping each rating value (1-5) to its count |
| `RecentComments` | The 5 most recent non-empty comments |

---

### Quality Dashboard

The quality dashboard aggregates all quality data into a single KPI view, supporting the analysis and evaluation requirement of ISO 9001 clause 9.1.3.

```csharp
QualityDashboardResponse dashboard = await _qualityDashBoardQuery
    .HandleAsync(companyId, from: DateTime.UtcNow.AddMonths(-3), end: DateTime.UtcNow);
```

The `QualityDashboardResponse` contains:

| Property | Description |
|---|---|
| `OpenNonConformities` | Count of nonconformities with open status |
| `ClosedNonConformities` | Count of resolved nonconformities |
| `AvarageResolutionDays` | Mean time to close a nonconformity |
| `TotalFeedbacks` | Total customer feedback entries |
| `AvarageRating` | Mean customer satisfaction rating |
| `IncidentsPerOrder` | Dictionary mapping entity IDs to incident counts |
| `TotalIncidentReports` | Total incident count in the period |
| `MonthlyKpis` | List of `MonthlyQualityKpi` with per-month breakdown |

---

### Audit Events (Unified Timeline)

The audit event query aggregates records from all modules (audit logs, feedback, incidents, nonconformities) into a single chronological timeline for a given entity. This is useful for building a complete history view.

```csharp
IEnumerable<AuditEventResponse> timeline = await _auditEventQuery
    .HandleAsync(entityId: orderId, companyId: tenantId);
```

Each `AuditEventResponse` contains:

| Property | Description |
|---|---|
| `Id` | Source record identifier |
| `EntityId` | Entity the event belongs to |
| `TimeStamp` | When the event occurred |
| `EventType` | Source module (`AuditLog`, `CustomerFeedback`, `IncidentReport`, `NonConformity`) |
| `Description` | Human-readable summary |
| `ResponsibleUser` | User associated with the event |

#### Extending with custom event providers

To add your own event source to the unified timeline, implement `IAuditEventProvider` and register it:

```csharp
public class ShipmentEventProvider : IAuditEventProvider
{
    public string EventType => "Shipment";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(
        string entityId, string companyId)
    {
        // Query your shipment data source
        var shipments = await _shipmentRepository.GetByOrderIdAsync(entityId, companyId);
        return shipments.Select(s => new AuditEventResponse(
            Id:              s.Id,
            EntityId:        entityId,
            TimeStamp:       s.ShippedAt,
            EventType:       EventType,
            Description:     $"Shipped via {s.Carrier}",
            ResponsibleUser: s.DispatchedBy
        ));
    }
}

// Registration
builder.Services.AddScoped<IAuditEventProvider, ShipmentEventProvider>();
```

---

### Generating Reports (PDF/HTML)

Every module exposes a report generation use case that returns a `ReportViewModel`. Render it using the `DigitalDoor.Reporting.Presenters.PDF` package included as a dependency.

```csharp
// Example: generate and return a PDF from an API endpoint
[HttpGet("companies/{companyId}/audit-report")]
public async Task<IActionResult> GetAuditReport(string companyId, DateTime? from, DateTime? to)
{
    ReportViewModel report = await _generateAuditReport
        .HandleAsync(companyId, entityId: null, from, to);

    byte[] pdf = PdfRenderer.Render(report);
    return File(pdf, "application/pdf", "audit-report.pdf");
}
```

Available report generators:

| Interface | Report |
|---|---|
| `IGenerateAuditLogReport` | Audit log entries |
| `IGenerateAuditReport` | Cross-module full audit report |
| `IGenerateCustomerFeedbackReport` | Customer feedback summary |
| `IGenerateIncidentReportReport` | Incident report document |
| `IGenerateNonConformityMasterReport` | Non-conformity master list |
| `IGenerateNonConformityDetailsReport` | Single non-conformity detail with corrective actions |

---

## Multi-Tenancy

Every entity and every query parameter includes a `CompanyId` field. The library performs no cross-tenant data isolation by itself — that responsibility falls on your data context implementations. Ensure your repository layer always filters by `CompanyId` in every query to maintain tenant separation.

---

## Data Context Contract Reference

Implement these interfaces in your infrastructure layer:

### Writable contexts (command side)

```csharp
IWritableAuditLogDataContext
IWritableCustomerFeedbackDataContext
IWritableIncidentReportDataContext
IWritableNonConformityDataContext
```

### Queryable contexts (query side)

```csharp
IQueryableAuditLogDataContext
IQueryableCustomerFeedbackDataContext
IQueryableIncidentReportDataContext
IQueryableNonConformityDataContext
```

Each queryable context exposes a `ToListAsync` method accepting an optional predicate and ordering function, matching the pattern used by EF Core and similar ORMs.

---

## Dependencies

| Package | Purpose |
|---|---|
| `Microsoft.Extensions.DependencyInjection.Abstractions` | DI extension methods |
| `DigitalDoor.Reporting` | Report model and rendering infrastructure |
| `DigitalDoor.Reporting.Presenters.PDF` | PDF export for generated reports |

---

## License

MIT License.
