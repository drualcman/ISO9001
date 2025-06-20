
using ISO9001.Database.InMemory.DataContexts.Entities;

namespace ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts
{
    internal static class InMemoryAuditLogStore
    {
        public static List<AuditLog> AuditLogs { get; } = new List<AuditLog>();
        public static int CurrentId { get; set; }
    }
}
