namespace ISO9001.Entities.Responses
{
    public class MonthlyQualityKpi(
        string year, string month, int nonConformities, int feedbacks)
    {
        public string Year => year;
        public string Month => month;
        public int NonConformities => nonConformities;
        public int Feedbacks => feedbacks;
    }
}
