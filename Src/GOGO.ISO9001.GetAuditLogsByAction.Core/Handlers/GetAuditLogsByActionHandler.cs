﻿using GOGO.ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.Entities.Responses;

namespace GOGO.ISO9001.GetAuditLogsByAction.Core.Handlers
{
    internal class GetAuditLogsByActionHandler(IGetAuditLogsByActionRepository repository) : IGetAuditLogsByActionInputPort
    {
        public async Task<IEnumerable<AuditLogResponse>> HandleAsync(string id, string action, DateTime? from, DateTime? end)
        {
            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetAuditLogsByActionAsync(id, action, UtcFrom, UtcEnd);
        }
    }
}

