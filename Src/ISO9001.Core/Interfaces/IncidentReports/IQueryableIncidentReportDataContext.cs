namespace ISO9001.Core.Interfaces.IncidentReports
{
    public interface IQueryableIncidentReportDataContext
    {
        IQueryable<IncidentReportReadModel> IncidentReports { get; }
        Task<IEnumerable<IncidentReportReadModel>> ToListAsync(
            IQueryable<IncidentReportReadModel> queryable);
    }
}

