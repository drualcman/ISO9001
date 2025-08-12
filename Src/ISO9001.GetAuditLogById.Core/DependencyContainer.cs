using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogById.Core.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.GetAuditLogById.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetAuditLogByIdCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditLogByIdInputPort, GetAuditLogByIdHandler>();
            return services;
        }
    }

}
