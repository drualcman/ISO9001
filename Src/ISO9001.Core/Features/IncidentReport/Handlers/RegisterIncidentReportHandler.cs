namespace ISO9001.Core.Features.IncidentReport.Handlers;

internal class RegisterIncidentReportHandler(ICommandIncidentReportRepository
    repository) : IRegisterIncidentReportInputPort
{
    public async Task HandleAsync(IncidentReportDto incidentReportDto)
    {
        await repository.RegisterIncidentReportAsync(incidentReportDto);
        await repository.SaveChangesAsync();
    }
}
