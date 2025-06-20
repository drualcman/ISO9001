using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByAction.Core.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogsByAction.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogsByActionCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditLogsByActionInputPort, GetAuditLogsByActionHandler>();
            return services;
        }
    }
}
