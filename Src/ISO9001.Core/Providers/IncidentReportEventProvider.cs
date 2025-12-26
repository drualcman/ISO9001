namespace ISO9001.Core.Providers;

internal class IncidentReportEventProvider(IQueryableIncidentReportDataContext context) : IAuditEventProvider
{
    public string EventType => "IncidentReport";

    public async Task<IEnumerable<AuditEventResponse>> GetAuditEventsAsync(string entityId, string companyId)
    {
        var IncidentReports = context.IncidentReports.Where
            (IncidentReport => IncidentReport.EntityId == entityId &&
                IncidentReport.CompanyId == companyId)
            .OrderBy(IncidentReport => IncidentReport.Id)
            .Select(IncidentReport => new AuditEventResponse(
                IncidentReport.Id.ToString(),
                IncidentReport.EntityId,
                IncidentReport.ReportedAt,
                EventType,
                IncidentReport.Description,
                IncidentReport.UserId
                ));

        return await Task.FromResult(IncidentReports);
    }
}
