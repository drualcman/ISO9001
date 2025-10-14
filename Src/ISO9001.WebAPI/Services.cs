namespace ISO9001.WebAPI
{
    public static class Services
    {
        public static WebApplicationBuilder AddISO9001Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuditLogCoreServices();
            builder.Services.AddCustomerFeedbackCoreServices();
            builder.Services.AddIncidentReportCoreServices();


            builder.Services.AddRegisterNonConformityServices();
            builder.Services.AddRegisterNonConformityDetailServices();
            builder.Services.AddGetAllNonConformitiesServices();
            builder.Services.AddGetNonConformityByAffectedProcessServices();
            builder.Services.AddGetNonConformityByEntityIdServices();
            builder.Services.AddGetNonConformityByStatusServices();

            builder.Services.AddGetAuditEventsServices();
            builder.Services.AddAuditEventsRepositories();

            builder.Services.AddGetQualityDashBoardServices();

            builder.Services.AddISO9001Repositories();
            builder.Services.AddDatabaseInMemory();
            return builder;
        }
    }
}
