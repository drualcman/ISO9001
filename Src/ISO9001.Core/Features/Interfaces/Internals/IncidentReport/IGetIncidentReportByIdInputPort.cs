using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGetIncidentReportByIdInputPort
{
    Task<IncidentReportResponse> HandleAsync(string companyId, int id);
}
