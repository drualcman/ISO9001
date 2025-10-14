namespace ISO9001.IncidentReport.Core.Internals.GetIncidentReportById
{
    public interface IGetIncidentReportByIdInputPort
    {
        Task<IncidentReportResponse> HandleAsync(string companyId, int id);
    }
}
