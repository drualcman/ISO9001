namespace ISO9001.Entities.Dtos
{
    public class CustomerFeedbackDto(
        string entityId, string companyId, string customerId, int rating,
        string comments)
    {
        public string EntityId => entityId;
        public string CompanyId => companyId;
        public string CustomerId => customerId;
        public int Rating => rating;
        public string Comments => comments;
    }
}
