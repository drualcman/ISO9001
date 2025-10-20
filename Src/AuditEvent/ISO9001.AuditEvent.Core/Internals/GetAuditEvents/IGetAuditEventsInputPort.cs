namespace ISO9001.AuditEvent.Core.Internals.GetAuditEvents
{
    public interface IGetAuditEventsInputPort
    {
        Task<IEnumerable<AuditEventResponse>> HandleAsync(string entityId, string companyId);

    }
}
