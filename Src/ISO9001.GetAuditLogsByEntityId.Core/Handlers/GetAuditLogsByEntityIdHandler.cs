﻿using ISO9001.Entities.Responses;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;

namespace ISO9001.GetAuditLogsByEntityId.Core.Handlers
{
    internal class GetAuditLogsByEntityIdHandler
        (IGetAuditLogsByEntityIdRepository repository) : IGetAuditLogsByEntityIdInputPort
    {
        public async Task<IEnumerable<AuditLogResponse>>
            HandleAsync(string id, string entityId, DateTime? from, DateTime? end)
        {

            DateTime UtcFrom = from != null ? from.Value.Date
                : DateTime.UtcNow.Date.AddDays(-30);

            DateTime UtcEnd = end != null ? end.Value.Date.AddDays(1).AddTicks(-1)
                : DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);

            return await repository.GetAuditLogsByEntityIdAsync(id, entityId, UtcFrom, UtcEnd);

        }
    }
}
