namespace ISO9001.Core.Providers;

internal class IncidentReportEventProvider(IQueryableIncidentReportDataContext context) : IAuditEventProvider
{
    public string EventType => "IncidentReport";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var data = await context.ToListAsync(IncidentReport => IncidentReport.EntityId == entityId &&
                IncidentReport.CompanyId == companyId,
                IncidentReport => IncidentReport.OrderBy(IncidentReport => IncidentReport.Id));

        return data.Select(IncidentReport => new AuditEventResponse(
                IncidentReport.Id.ToString(),
                IncidentReport.EntityId,
                IncidentReport.ReportedAt,
                EventType,
                IncidentReport.Description,
                IncidentReport.UserId));
    }
}
