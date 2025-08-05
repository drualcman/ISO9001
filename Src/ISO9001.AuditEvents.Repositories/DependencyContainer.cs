using ISO9001.GetAuditEvents.BusinessObjects.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.AuditEvents.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditEventsRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditEventsRepository, GetAuditEventsRepository>();
            return services;
        }
    }

}
