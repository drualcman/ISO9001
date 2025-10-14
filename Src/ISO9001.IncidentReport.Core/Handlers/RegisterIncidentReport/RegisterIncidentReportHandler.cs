namespace ISO9001.IncidentReport.Core.Handlers.RegisterIncidentReport
{
    internal class RegisterIncidentReportHandler(ICommandIncidentReportRepository
        repository) : IRegisterIncidentReportInputPort
    {
        public async Task HandleAsync(IncidentReportDto incidentReportDto)
        {
            await repository.RegisterIncidentReportAsync(incidentReportDto);
            await repository.SaveChangesAsync();
        }
    }
}
