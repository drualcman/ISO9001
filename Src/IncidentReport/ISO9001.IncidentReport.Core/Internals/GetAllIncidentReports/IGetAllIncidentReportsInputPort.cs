namespace ISO9001.IncidentReport.Core.Internals.GetAllIncidentReports
{
    public interface IGetAllIncidentReportsInputPort
    {
        Task<IEnumerable<IncidentReportResponse>> HandleAsync(string id, DateTime? from, DateTime? end);

    }
}
