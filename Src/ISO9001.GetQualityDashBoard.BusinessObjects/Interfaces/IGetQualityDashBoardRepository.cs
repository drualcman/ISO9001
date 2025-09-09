using ISO9001.Entities.Responses;

namespace ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces
{
    public interface IGetQualityDashBoardRepository
    {
        Task<int> GetNonConformitiesCountByStatus(string companyId, string status,DateTime? from, DateTime? end);
        Task<int> GetOpenNonConformitiesCount(string companyId, string closedStatus, DateTime? from, DateTime? end);
        Task<TimeSpan> GetAverageResolutionDays(string companyId, DateTime? from, DateTime? end);
        Task<int> GetTotalCustomerFeedbacks(string companyId, DateTime? from, DateTime? end);
        Task<double> GetAverageRatingOfCustomerFeedback(string companyId, DateTime? from, DateTime? end);
        Task<int> GetTotalIncidentReports(string companyId, DateTime? from, DateTime? end);
        Task<Dictionary<string, int>> GetIncidentReportsByEntityId(string companyId, DateTime? from, DateTime? end);
        Task<List<MonthlyQualityKpi>> GetMonthlyQualityKpis(string companyId, DateTime? from, DateTime? end);

    }
}
