using ISO9001.Core.Interfaces;

namespace ISO9001.Core.Repositories.IncidentReportRepositories;

internal class CommandIncidentReportRepository(IWritableIncidentReportDataContext
    dataContext) : ICommandIncidentReportRepository
{
    public async Task RegisterIncidentReportAsync(IncidentReportDto incidentReportDto)
    {
        var NewIncidentReport = new IncidentReport
        {
            CompanyId = incidentReportDto.CompanyId,
            EntityId = incidentReportDto.EntityId,
            ReportedAt = incidentReportDto.ReportedAt,
            UserId = incidentReportDto.UserId,
            Description = incidentReportDto.Description,
            AffectedProcess = incidentReportDto.AffectedProcess,
            Severity = incidentReportDto.Severity,
            Data = incidentReportDto.Data
        };

        await dataContext.AddAsync(NewIncidentReport);
    }

    public Task SaveChangesAsync() => dataContext.SaveChangesAsync();
}
