using ISO9001.NonConformity.Core;

namespace ISO9001.WebAPI
{
    public static class Services
    {
        public static WebApplicationBuilder AddISO9001Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuditLogCoreServices();
            builder.Services.AddCustomerFeedbackCoreServices();
            builder.Services.AddIncidentReportCoreServices();
            builder.Services.AddNonConformityCoreServices();
            builder.Services.AddGetAuditEventsServices();


            builder.Services.AddISO9001Repositories();
            builder.Services.AddGetQualityDashBoardServices();
            builder.Services.AddAuditEventsRepositories();


            builder.Services.AddDatabaseInMemory();
            return builder;
        }
    }
}
