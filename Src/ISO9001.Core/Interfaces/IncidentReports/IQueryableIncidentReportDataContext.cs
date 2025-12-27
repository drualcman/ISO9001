namespace ISO9001.Core.Interfaces.IncidentReports
{
    public interface IQueryableIncidentReportDataContext
    {
        Task<IEnumerable<IncidentReportReadModel>> ToListAsync(
            Expression<Func<IncidentReportReadModel, bool>> filter = null,
            Func<IQueryable<IncidentReportReadModel>, IOrderedQueryable<IncidentReportReadModel>> orderBy = null);
    }
}

