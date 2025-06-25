using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByRatingRepository
    {
        Task<IEnumerable<CustomerFeedbackResponse>> GetCustomerFeedbackByRatingAsync(string id, int  rating, DateTime? from, DateTime? end);
    }
}
