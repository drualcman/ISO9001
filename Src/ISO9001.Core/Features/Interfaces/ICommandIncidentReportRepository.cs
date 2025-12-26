using ISO9001.Core.Dtos;

namespace ISO9001.Core.Features.Interfaces;

public interface ICommandIncidentReportRepository
{
    Task RegisterIncidentReportAsync(IncidentReportDto incidentReport);
    Task SaveChangesAsync();
}
