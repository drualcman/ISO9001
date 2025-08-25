using ISO9001.Entities.Responses;

namespace ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces
{
    public interface IGetQualityDashBoardInputPort
    {
        Task<QualityDashboardResponse> HandleAsync(string companyId, DateTime? from, DateTime? end);
    }
}
