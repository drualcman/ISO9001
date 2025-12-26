namespace ISO9001.Core.Interfaces.DashBoards;

public interface IQualityDashBoardQuery
{
    Task<QualityDashboardResponse> HandleAsync(string companyId, DateTime? from, DateTime? end);

}
