﻿using ISO9001.GetAllAuditLogs.BusinessObjects.Interfaces;
using ISO9001.GetAllCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.GetAllIncidentReports.BusinessObjects.Interfaces;
using ISO9001.GetAllNonConformities.BusinessObjects;
using ISO9001.GetAuditLogById.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByAction.BusinessObjects.Interfaces;
using ISO9001.GetAuditLogsByEntityIdBusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByCustomerId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByEntityId.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackById.BusinessObjects.Interfaces;
using ISO9001.GetCustomerFeedbackByRating.BusinessObjects.Interfaces;
using ISO9001.GetIncidentReportById.BusinessObjects.Interfaces;
using ISO9001.GetNonConformityByAffectedProcess.BusinessObjects;
using ISO9001.GetNonConformityByEntityId.BusinessObjects;
using ISO9001.GetNonConformityByStatus.BusinessObjects;
using ISO9001.GetQualityDashBoard.BusinessObjects.Interfaces;
using ISO9001.Interfaces.Interfaces;
using ISO9001.RegisterAuditLog.BusinessObjects.Interfaces;
using ISO9001.RegisterCustomerFeedback.BusinessObjects.Interfaces;
using ISO9001.RegisterIncidentReport.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformity.BusinessObjects.Interfaces;
using ISO9001.RegisterNonConformityDetail.BusinessObjects.Interfaces;
using ISO9001.Repositories.AuditLogRepositories;
using ISO9001.Repositories.AuditLogRepositories.AuditEventProvider;
using ISO9001.Repositories.CustomerFeedbackRepositories;
using ISO9001.Repositories.CustomerFeedbackRepositories.AuditEventProvider;
using ISO9001.Repositories.DashBoardRepositories;
using ISO9001.Repositories.IncidentReportRepositories;
using ISO9001.Repositories.IncidentReportRepositories.AuditEventProvider;
using ISO9001.Repositories.NonConformityRepositories;
using ISO9001.Repositories.NonConformityRepositories.AuditEventProvider;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Repositories
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddISO9001Repositories(this IServiceCollection services)
        {
            services.AddScoped<IRegisterAuditLogRepository, RegisterAuditLogRepository>();
            services.AddScoped<IGetAllAuditLogsRepository, GetAllAuditLogsRepository>();
            services.AddScoped<IGetAuditLogsByEntityIdRepository, GetAuditLogsByEntityIdRepository>();
            services.AddScoped<IGetAuditLogsByActionRepository, GetAuditLogsByActionRepository>();
            services.AddScoped<IGetAuditLogByIdRepository, GetAuditLogByIdRepository>();

            services.AddScoped<IRegisterCustomerFeedbackRepository, RegisterCustomerFeedbackRepository>();
            services.AddScoped<IGetAllCustomerFeedbackRepository, GetAllCustomerFeedbackRepository>();
            services.AddScoped<IGetCustomerFeedbackByIdRepository, GetCustomerFeedbackByIdRepository>();
            services.AddScoped<IGetCustomerFeedbackByEntityIdRepository, GetCustomerFeedbackByEntityIdRepository>();
            services.AddScoped<IGetCustomerFeedbackByCustomerIdRepository, GetCustomerFeedbackByCustomerIdRepository>();
            services.AddScoped<IGetCustomerFeedbackByRatingRepository, GetCustomerFeedbackByRatingRepository>();

            services.AddScoped<IRegisterIncidentReportRepository, RegisterIncidentReportRepository>();
            services.AddScoped<IGetAllIncidentReportsRepository, GetAllIncidentReportsRepository>();
            services.AddScoped<IGetIncidentReportByIdRepository, GetIncidentReportByIdRepository>();

            services.AddScoped<IRegisterIncidentReportRepository, RegisterIncidentReportRepository>();
            services.AddScoped<IGetAllIncidentReportsRepository, GetAllIncidentReportsRepository>();
            services.AddScoped<IGetIncidentReportByIdRepository, GetIncidentReportByIdRepository>();

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
