using ISO9001.AuditEvent.Core;
using ISO9001.AuditReport.Core;
using ISO9001.NonConformity.Core;
using ISO9001.QualityDashBoard.Core;

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
            builder.Services.AddQualityDashboardCoreServices();
            builder.Services.AddAuditEventCoreServices();
            builder.Services.AddAuditReportCoreServices();

            builder.Services.AddReportingPresenterPdfServices();
            builder.Services.AddISO9001Repositories();
            builder.Services.AddDatabaseInMemory();
            return builder;
        }
    }
}
