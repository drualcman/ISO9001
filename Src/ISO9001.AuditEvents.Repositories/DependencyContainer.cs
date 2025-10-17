namespace ISO9001.AuditEvents.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuditEventsRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQueryableAuditEventRepository, QueryableAuditEventRepository>();
            return services;
        }
    }

}
