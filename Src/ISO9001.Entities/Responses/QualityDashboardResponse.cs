namespace ISO9001.Entities.Responses
{
    public class QualityDashboardResponse(int openNonConformities, int closedNonConformities,
        int totalFeedbacks, double avarageRating, int totalIncidentReports)
    {
        public int OpenNonConformities => openNonConformities;
        public int ClosedNonConformities => closedNonConformities;
        public int TotalFeedbacks => totalFeedbacks;
        public double AvarageRating => avarageRating;
        public int TotalIncidentReports => totalIncidentReports;
    }
}
