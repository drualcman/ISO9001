using ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces;
using ISO9001.Repositories.CustomerFeedbackRepositories.Entities;
using ISO9001.Repositories.CustomerFeedbackRepositories.Interfaces;
using ISO9001.Repositories.IncidentReportRepositories.Interfaces;
using ISO9001.Repositories.NonConformityRepositories.Interfaces;

namespace ISO9001.Repositories.DashBoardRepositories
{
    internal class GetQualityDashBoardRepository(
        IQueryableNonConformityDataContext nonConformityDataContext,
        IQueryableCustomerFeedbackDataContext customerFeedbackDataContext,
        IQueryableIncidentReportDataContext incidentReportDataContext) : IGetQualityDashBoardRepository
    {

        public Task<int> GetNonConformitiesCountByStatus(string companyId, string status,
            DateTime? from, DateTime? end) =>
            Task.FromResult(nonConformityDataContext.NonConformities
                .Where(NonConformity =>
                NonConformity.CompanyId == companyId &&
                NonConformity.Status.ToLower() == status.ToLower() &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= from)
                .Count());


        public Task<int> GetOpenNonConformitiesCount(string companyId, string closedStatus,
            DateTime? from, DateTime? end) =>
            Task.FromResult(nonConformityDataContext.NonConformities
                .Where(NonConformity =>
                NonConformity.CompanyId == companyId &&
                NonConformity.Status.ToLower() != closedStatus.ToLower() &&
                NonConformity.ReportedAt >= from &&
                NonConformity.ReportedAt <= from)
                .Count());

        public Task<int> GetTotalCustomerFeedbacks(string companyId, DateTime? from, DateTime? end) =>
            Task.FromResult(customerFeedbackDataContext.CustomerFeedbacks
                .Where(CustomerFeedback =>
                CustomerFeedback.CompanyId == companyId &&
                CustomerFeedback.ReportedAt >= from &&
                CustomerFeedback.ReportedAt <= end)
                .Count());

        public Task<double> GetAvarageRatingOfCustomerFeedback(string companyId, DateTime? from, DateTime? end)
        {
            var Total = GetTotalCustomerFeedbacks(companyId, from, end);
            double Amount = 0;

            foreach (CustomerFeedbackReadModel customerFeedback in customerFeedbackDataContext.CustomerFeedbacks)
            {
                Amount += customerFeedback.Rating;
            }

            return Task.FromResult(Amount);
        }

        public Task<int> GetTotalIncidentReports(string companyId, DateTime? from, DateTime? end) =>
            Task.FromResult(incidentReportDataContext.IncidentReports
                .Where(IncidentReport =>
                IncidentReport.CompanyId == companyId &&
                IncidentReport.ReportedAt >= from &&
                IncidentReport.ReportedAt <= end)
                .Count());


    }
}
