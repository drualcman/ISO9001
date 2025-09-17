
using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts
{
    internal class InMemoryAuditLogStore
    {
        public List<AuditLog> AuditLogs { get; } = new ();
        public int CurrentId { get; set; }
    }
}
