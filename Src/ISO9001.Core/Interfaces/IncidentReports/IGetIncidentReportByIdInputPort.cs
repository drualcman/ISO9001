namespace ISO9001.Core.Interfaces.IncidentReports;

public interface IGetIncidentReportByIdInputPort
{
    Task<IncidentReportResponse> HandleAsync(string companyId, int id);
}
