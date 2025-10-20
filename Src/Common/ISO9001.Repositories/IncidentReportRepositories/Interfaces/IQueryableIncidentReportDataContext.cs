namespace ISO9001.Repositories.IncidentReportRepositories.Interfaces
{
    public interface IQueryableIncidentReportDataContext
    {
        IQueryable<IncidentReportReadModel> IncidentReports { get; }
        Task<IEnumerable<IncidentReportReadModel>> ToListAsync(
            IQueryable<IncidentReportReadModel> queryable);
    }
}

