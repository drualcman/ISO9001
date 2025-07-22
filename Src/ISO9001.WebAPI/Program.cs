using ISO9001.GetAllAuditLogs.Rest.Mappings;
using ISO9001.GetAllCustomerFeedback.Rest.Mappings;
using ISO9001.GetAllIncidentReports.Rest.Mappings;
using ISO9001.GetAllNonConformities.Rest.Mappings;
using ISO9001.GetAuditLogsByAction.Rest.Mappings;
using ISO9001.GetAuditLogsByEntityId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackByCustomerId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackByEntityId.Rest.Mappings;
using ISO9001.GetCustomerFeedbackByRating.Rest.Mappings;
using ISO9001.GetNonConformityByAffectedProcess.Rest.Mappings;
using ISO9001.GetNonConformityByEntityId.Rest.Mappings;
using ISO9001.GetNonConformityByStatus.Rest.Mappings;
using ISO9001.RegisterAuditLog.Rest.Mappings;
using ISO9001.RegisterCustomerFeedback.Rest.Mappings;
using ISO9001.RegisterIncidentReport.Rest.Mappings;
using ISO9001.RegisterNonConformity.Rest.Mappings;
using ISO9001.RegisterNonConformityDetail.Rest.Mappings;
using ISO9001.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.AddISO9001Services();

builder.Services.AddWebApiDocumentator(options =>
{
    options.ApiName = "GOGO.ISO9001";
    options.Version = "v1";
    options.Description = "Implementación de ISO 9001";
    options.DocsBaseUrl = "docs/api";
    options.ShopOpenApiLink = true;
#if DEBUG
    options.EnableTesting = true;
#else
    options.EnableTesting = false;
#endif
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(config =>
    {
        config.AllowAnyMethod();
        config.AllowAnyHeader();
        config.AllowAnyOrigin();
    });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseWebApiDocumentator();

app.UseGetAllAuditLogsEndpoint();
app.UseGetAuditLogByActionEndpoint();
app.UseGetAuditLogsByEntityIdEndpoint();
app.UseRegisterAuditLogEndpoint();

app.UseGetCustomerFeedbackByRatingEndpoint();
app.UseGetAllCustomerFeedbackEndpoints();
app.UseGetCustomerFeedbackByCustomerIdEndpoint();
app.UseGetCustomerFeedbackByEntityIdEndpoint();
app.UseRegisterCustomerFeedbackEndpoint();

app.UseGetAllIncidentReportsEndpoint();
app.UseRegisterIncidentReportEndpoint();

app.UseGetAllNonConformitiesEndpoint();
app.UseGetNonConformityByAffectedProcessEndpoint();
app.UseGetNonConformityByEntityIdEndpoint();
app.UseGetNonConformityByStatusEndpoint();
app.UseRegisterNonConformityEndpoint();
app.UseRegisterNonConformityDetailEndpoint();

app.UseHttpsRedirection();
app.UseCors();

app.Run();
