using ISO9001.IncidentReports.Repositories.Entities;

namespace ISO9001.IncidentReports.Repositories.Interfaces
{
    public interface IQueryableIncidentReportDataContext
    {
        IQueryable<IncidentReportReadModel> IncidentReports { get; }
        Task<IEnumerable<ReturnType>> ToListAsync<ReturnType>(
            IQueryable<ReturnType> queryable);
    }
}

