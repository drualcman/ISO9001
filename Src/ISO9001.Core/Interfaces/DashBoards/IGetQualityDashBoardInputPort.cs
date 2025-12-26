namespace ISO9001.Core.Interfaces.DashBoards;

public interface IGetQualityDashBoardInputPort
{
    Task<QualityDashboardResponse> HandleAsync(string companyId, DateTime? from, DateTime? end);

}
