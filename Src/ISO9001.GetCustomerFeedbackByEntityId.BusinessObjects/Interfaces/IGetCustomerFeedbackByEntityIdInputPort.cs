﻿using ISO9001.Entities.Responses;

namespace ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces
{
    public interface IGetCustomerFeedbackByEntityIdInputPort
    {
        Task<IEnumerable<CustomerFeedbackResponse>> HandleAsync(string id, string entityId);
    }
}
