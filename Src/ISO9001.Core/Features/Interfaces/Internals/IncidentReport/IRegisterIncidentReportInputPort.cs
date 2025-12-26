using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces.Internals.IncidentReport;

public interface IRegisterIncidentReportInputPort
{
    Task HandleAsync(IncidentReportDto incidentReportDto);
}
