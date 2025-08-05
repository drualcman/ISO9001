using ISO9001.GetAuditEvents.BusinessObjects.Interfaces;
using ISO9001.GetAuditEvents.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditEvents.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditEventsCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditEventsInputPort, GetAuditEventsHandler>();
            return services;
        }
    }

}
