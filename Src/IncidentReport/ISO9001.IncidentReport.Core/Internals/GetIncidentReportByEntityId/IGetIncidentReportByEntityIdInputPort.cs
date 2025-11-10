namespace ISO9001.IncidentReport.Core.Internals.GetIncidentReportByEntityId
{
    public interface IGetIncidentReportByEntityIdInputPort
    {
        Task<IEnumerable<IncidentReportResponse>> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
    }
}
