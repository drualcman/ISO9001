﻿using ISO9001.AuditEvents.Repositories;
using ISO9001.Database.InMemory;
using ISO9001.GetAllAuditLogs.IoC;
using ISO9001.GetAllCustomerFeedback.IoC;
using ISO9001.GetAllIncidentReports.IoC;
using ISO9001.GetAllNonConformities.IoC;
using ISO9001.GetAuditEvents.IoC;
using ISO9001.GetAuditLogById.IoC;
using ISO9001.GetAuditLogsByAction.IoC;
using ISO9001.GetAuditLogsByEntityId.IoC;
using ISO9001.GetCustomerFeedbackByCustomerId.IoC;
using ISO9001.GetCustomerFeedbackByEntityId.IoC;
using ISO9001.GetCustomerFeedbackById.IoC;
using ISO9001.GetCustomerFeedbackByRating.IoC;
using ISO9001.GetIncidentReportById.IoC;
using ISO9001.GetNonConformityByAffectedProcess.IoC;
using ISO9001.GetNonConformityByEntityId.IoC;
using ISO9001.GetNonConformityByStatus.IoC;
using ISO9001.RegisterAuditLog.IoC;
using ISO9001.RegisterCustomerFeedback.IoC;
using ISO9001.RegisterIncidentReportIoC;
using ISO9001.RegisterNonConformityDetail.IoC;
using ISO9001.RegisterNonConformityIoC;
using ISO9001.Repositories;

namespace ISO9001.WebAPI
{
    public static class Services
    {
        public static WebApplicationBuilder AddISO9001Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddGetAllAuditLogsServices();
            builder.Services.AddGetAuditLogByIdServices();
            builder.Services.AddGetAuditLogsByEntityIdServices();
            builder.Services.AddGetAuditLogsByActionServices();
            builder.Services.AddRegisterAuditLogServices();

            builder.Services.AddRegisterCustomerFeedbackServices();
            builder.Services.AddGetAllCustomerFeedbackServices();
            builder.Services.AddGetCustomerFeedbackByIdServices();
            builder.Services.AddGetCustomerFeedbackByEntityIdServices();
            builder.Services.AddGetCustomerFeedbackByCustomerIdServices();
            builder.Services.AddGetCustomerFeedbackByRatingServices();

            builder.Services.AddRegisterIncidentReportServices();
            builder.Services.AddGetAllIncidentReportServices();
            builder.Services.AddGetIncidentReportByIdServices();

            builder.Services.AddRegisterNonConformityServices();
            builder.Services.AddRegisterNonConformityDetailServices();
            builder.Services.AddGetAllNonConformitiesServices();
            builder.Services.AddGetNonConformityByAffectedProcessServices();
            builder.Services.AddGetNonConformityByEntityIdServices();
            builder.Services.AddGetNonConformityByStatusServices();

            builder.Services.AddGetAuditEventsServices();
            builder.Services.AddAuditEventsRepositories();

            builder.Services.AddISO9001Repositories();
            builder.Services.AddDatabaseInMemory();
            return builder;
        }
    }
}
