using ISO9001.Entities.Responses;
using ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces;

namespace ISO9001.GetQualityDashBoard.Core.Handlers
{
    internal class GetQualityDashBoardHandler(
        IGetQualityDashBoardRepository repository) : IGetQualityDashBoardInputPort
    {
        private const string NonConformityStatusClosed = "closed";

        public async Task<QualityDashboardResponse> HandleAsync(string companyId,
            DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            int ClosedNonConformities =
                await repository.GetNonConformitiesCountByStatus(companyId, NonConformityStatusClosed, UtcFrom, UtcEnd);

            int OpenNonConformities =
                await repository.GetOpenNonConformitiesCount(companyId, NonConformityStatusClosed, UtcFrom, UtcEnd);

            TimeSpan AvarageNonConformityResolutionDays =
                await repository.GetAverageResolutionDays(companyId, UtcFrom, UtcEnd);

            int CustomerFeedbacks = await repository.GetTotalCustomerFeedbacks(companyId, UtcFrom, UtcEnd);

            double AvarageCustomerFeedback = await repository.GetAverageRatingOfCustomerFeedback(companyId, UtcFrom, UtcEnd);

            int IncidentReports = await repository.GetTotalIncidentReports(companyId, UtcFrom, UtcEnd);

            Dictionary<string, int> IncidentsPerOrder = await repository.GetIncidentReportsByEntityId(companyId, UtcFrom, UtcEnd);

            List<MonthlyQualityKpi> MonthlyQualityKpis = await repository.GetMonthlyQualityKpis(companyId, UtcFrom, UtcEnd);
 
            return new QualityDashboardResponse(
                OpenNonConformities,
                ClosedNonConformities,
                AvarageNonConformityResolutionDays,
                CustomerFeedbacks,
                AvarageCustomerFeedback,
                IncidentsPerOrder,
                IncidentReports,
                MonthlyQualityKpis
                );

        }
    }
}
