using ISO9001.Core.Responses;

namespace ISO9001.Core.Features.Interfaces.Internals.DashBoard
{
    public interface IGetQualityDashBoardInputPort
    {
        Task<QualityDashboardResponse> HandleAsync(string companyId, DateTime? from, DateTime? end);

    }
}
