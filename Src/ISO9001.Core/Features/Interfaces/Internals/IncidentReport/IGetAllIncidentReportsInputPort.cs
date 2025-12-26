using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IGetAllIncidentReportsInputPort
{
    Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end);

}
