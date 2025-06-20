using ISO9001.WebAPI;
using ISO9001.WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.AddISO9001Services();

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
    app.UseWebApiDocumentator();
}

app.UseHttpsRedirection();
app.UserAuditLogEndpoints();
app.UserCustomerFeedbackEndpoints();
app.UserIncidentReportEndpoints();
app.UserNonConformityEndpoints();
app.UseCors();

app.Run();