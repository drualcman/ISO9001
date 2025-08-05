using ISO9001.GetAuditEvents.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditEvents.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditEventsServices(this IServiceCollection services)
        {
            services.AddGetAuditEventsCoreServices();
            return services;
        }
    }

}
