namespace ISO9001.Core.Interfaces
{
    public interface IQueryableIncidentReportDataContext
    {
        IQueryable<IncidentReportReadModel> IncidentReports { get; }
        Task<IEnumerable<IncidentReportReadModel>> ToListAsync(
            IQueryable<IncidentReportReadModel> queryable);
    }
}

