using ISO9001.Entities.Dtos;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.Repositories.Entities;
using ISO9001.RegisterIncidentReport.Repositories.Interfaces;

namespace ISO9001.RegisterIncidentReport.Repositories
{
    internal class RegisterIncidentReportRepository(
        IRegisterIncidentReportDataContext dataContext) : IRegisterIncidentReportRepository
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
}
