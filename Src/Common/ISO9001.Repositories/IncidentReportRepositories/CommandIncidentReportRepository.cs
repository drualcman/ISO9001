using ISO9001.Entities.Dtos;
using ISO9001.Repositories.IncidentReportRepositories.Interfaces;

namespace ISO9001.Repositories.IncidentReportRepositories
{
    internal class CommandIncidentReportRepository(IWritableIncidentReportDataContext
        dataContext) : ICommandIncidentReportRepository
    {
        public async Task RegisterIncidentReportAsync(IncidentReportDto incidentReportDto)
        {
            var NewIncidentReport = new Entities.IncidentReport
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
}
