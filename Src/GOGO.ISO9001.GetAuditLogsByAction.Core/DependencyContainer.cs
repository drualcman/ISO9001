using GOGO.ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using GOGO.ISO9001.GetAuditLogsByAction.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GOGO.ISO9001.GetAuditLogsByAction.Core
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
