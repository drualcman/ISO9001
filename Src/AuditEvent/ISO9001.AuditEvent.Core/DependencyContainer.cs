namespace ISO9001.AuditEvent.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditEventCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAuditEventsInputPort, GetAuditEventsHandler>();
            return services;
        }
    }

}
