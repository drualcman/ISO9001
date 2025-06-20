using ISO9001.RegisterAuditLog.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterAuditLog.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRegisterAuditLogServices(this IServiceCollection services)
        {
            services.AddAuditLogCoreServices();
            return services;
        }
    }
}
