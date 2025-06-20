using ISO9001.Entities.Dtos;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;

namespace ISO9001.RegisterIncidentReport.Core.Handlers
{
    internal class RegisterIncidentReportHandler(IRegisterIncidentReportRepository
        repository) : IRegisterIncidentReportInputPort
    {
        public async Task HandleAsync(IncidentReportDto incidentReportDto)
        {
            await repository.RegisterIncidentReportAsync(incidentReportDto);
            await repository.SaveChangesAsync();
        }
    }
}
