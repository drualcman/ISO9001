using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using ISO9001.RegisterAuditLog.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.RegisterAuditLog.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditLogCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterAuditLogInputPort, RegisterAuditLogHandler>();
            return services;
        }
    }
}
