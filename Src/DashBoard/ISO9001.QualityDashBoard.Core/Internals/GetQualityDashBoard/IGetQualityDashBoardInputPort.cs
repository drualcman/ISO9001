namespace ISO9001.QualityDashBoard.Core.Internals.GetQualityDashBoard
{
    public interface IGetQualityDashBoardInputPort
    {
        Task<QualityDashboardResponse> HandleAsync(string companyId, DateTime? from, DateTime? end);

    }
}
