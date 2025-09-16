namespace ISO9001.Entities.Responses
{
    public class QualityDashboardResponse(int openNonConformities, int closedNonConformities,
        TimeSpan avarageResolutionDays, int totalFeedbacks, double avarageRating, 
        Dictionary<string, int> incidentsPerOrder, int totalIncidentReports,
        List<MonthlyQualityKpi> monthlyKpis)
    {
        public int OpenNonConformities => openNonConformities; // YA
        public int ClosedNonConformities => closedNonConformities; // YA
        public TimeSpan AvarageResolutionDays => avarageResolutionDays; // YA
        public int TotalFeedbacks => totalFeedbacks; // YA
        public double AvarageRating => avarageRating; // YA 
        public Dictionary<string, int> IncidentsPerOrder => incidentsPerOrder;
        public int TotalIncidentReports => totalIncidentReports;
        public List<MonthlyQualityKpi> MonthlyKpis => monthlyKpis;
    }
}
