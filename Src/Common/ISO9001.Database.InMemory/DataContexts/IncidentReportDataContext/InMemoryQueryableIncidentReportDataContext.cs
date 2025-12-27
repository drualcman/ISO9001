using System.Linq.Expressions;

namespace ISO9001.Database.InMemory.DataContexts.IncidentReportDataContext;

internal class InMemoryQueryableIncidentReportDataContext(
    InMemoryIncidentReportStore dataContext) : IQueryableIncidentReportDataContext
{
    private IQueryable<IncidentReportReadModel> IncidentReports =>
        dataContext.IncidentReports
        .Select(IncidentReport => new IncidentReportReadModel
        {
            Id = IncidentReport.Id,
            CompanyId = IncidentReport.CompanyId,
            EntityId = IncidentReport.EntityId,
            ReportedAt = IncidentReport.ReportedAt,
            CreatedAt = IncidentReport.CreatedAt,
            UserId = IncidentReport.UserId,
            Description = IncidentReport.Description,
            AffectedProcess = IncidentReport.AffectedProcess,
            Severity = IncidentReport.Severity,
            Data = IncidentReport.Data
        }).AsQueryable();

    public async Task<IEnumerable<IncidentReportReadModel>> ToListAsync(
        Expression<Func<IncidentReportReadModel, bool>> filter = null,
        Func<IQueryable<IncidentReportReadModel>, IOrderedQueryable<IncidentReportReadModel>> orderBy = null)
    {
        IQueryable<IncidentReportReadModel> query = IncidentReports;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = query.ToList();
        return await Task.FromResult(data);
    }

}

