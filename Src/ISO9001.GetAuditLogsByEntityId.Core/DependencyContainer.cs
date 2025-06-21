using ISO9001.GetAuditLogsByEntityId.Core.Handlers;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogsByEntityId.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogsByEntityIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditLogsByEntityIdInputPort, GetAuditLogsByEntityIdHandler>();

            return services;
        }
    }
}
