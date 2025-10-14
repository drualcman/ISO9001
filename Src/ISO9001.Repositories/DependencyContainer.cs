namespace ISO9001.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddISO9001Repositories(this IServiceCollection services)
        {
            services.AddScoped<ICommandAuditLogRepository, CommandAuditLogRepository>();
            services.AddScoped<IQueryableAuditLogRepository, QueryableAuditLogRepository>();

            services.AddScoped<ICommandCustomerFeedbackRepository, CommandCustomerFeedbackRepository>();
            services.AddScoped<IQueryableCustomerFeedbackRepository, QueryableCustomerFeedbackRepository>();

            services.AddScoped<ICommandIncidentReportRepository, CommandIncidentReportRepository>();
            services.AddScoped<IQueryableIncidentReportRepository, QueryableIncidentReportRepository>();

            services.AddScoped<IRegisterNonConformityRepository, RegisterNonConformityRepository>();
            services.AddScoped<IRegisterNonConformityDetailRepository, RegisterNonConformityDetailRepository>();
            services.AddScoped<IGetAllNonConformitiesRepository, GetAllNonConformitiesRepository>();
            services.AddScoped<IGetNonConformityByAffectedProcessRepository, GetNonConformityByAffectedProcessRepository>();
            services.AddScoped<IGetNonConformityByEntityIdRepository, GetNonConformityByEntityIdRepository>();
            services.AddScoped<IGetNonConformityByStatusRepository, GetNonConformityByStatusRepository>();

            services.AddScoped<IGetQualityDashBoardRepository, GetQualityDashBoardRepository>();

            services.AddScoped<IAuditEventProvider, AuditLogEventProvider>();
            services.AddScoped<IAuditEventProvider, CustomerFeedbackEventProvider>();
            services.AddScoped<IAuditEventProvider, IncidentReportEventProvider>();
            services.AddScoped<IAuditEventProvider, IncidentReportEventProvider>();
            services.AddScoped<IAuditEventProvider, NonConformityEventProvider>();
            return services;
        }
    }
}
