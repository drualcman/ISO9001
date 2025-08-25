namespace ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces
{
    public interface IGetQualityDashBoardRepository
    {
        Task<int> GetNonConformitiesCountByStatus(string companyId, string status,DateTime? from, DateTime? end);
        Task<int> GetOpenNonConformitiesCount(string companyId, string closedStatus, DateTime? from, DateTime? end);
        Task<int> GetTotalCustomerFeedbacks(string companyId, DateTime? from, DateTime? end);
        Task<double> GetAvarageRatingOfCustomerFeedback(string companyId, DateTime? from, DateTime? end);
        Task<int> GetTotalIncidentReports(string companyId, DateTime? from, DateTime? end);

    }
}
