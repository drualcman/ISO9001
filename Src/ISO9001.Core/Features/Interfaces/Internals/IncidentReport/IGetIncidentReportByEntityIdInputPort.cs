using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGetIncidentReportByEntityIdInputPort
{
    Task<IEnumerable<IncidentReportResponse>> HandleAsync(string companyId, string entityId, DateTime? from, DateTime? end);
}
