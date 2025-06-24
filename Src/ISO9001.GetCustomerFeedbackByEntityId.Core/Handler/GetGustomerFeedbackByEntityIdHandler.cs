using ISO9001.Entities.Responses;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;

namespace ISO9001.GetCustomerFeedbackByEntityId.Core.Handler
{
    internal class GetGustomerFeedbackByEntityIdHandler(
        IGetCustomerFeedbackByEntityIdRepository repository): IGetCustomerFeedbackByEntityIdInputPort
    {
        public async Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string entityId)
        {
            return await repository.GetCustomerFeedbackByEntityId(id, entityId);
        }

    }
}
