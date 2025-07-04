﻿using ISO9001.AuditLogs.Repositories.Interfaces;
using ISO9001.CustomerFeedbacks.Repositories.Interfaces;
using ISO9001.Database.InMemory.DataContexts;
using ISO9001.Database.InMemory.DataContexts.AuditLogDataContexts;
using ISO9001.Database.InMemory.DataContexts.CustomerFeedbackDataContext;
using ISO9001.Database.InMemory.DataContexts.NonConformityDataContext;
using ISO9001.NonConformities.Repositories.Interfaces;
using ISO9001.RegisterIncidentReport.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ISO9001.Database.InMemory
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDatabaseInMemory(this IServiceCollection services)
        {
            services.AddScoped<IRegisterAuditLogDataContext, InMemoryRegisterAuditLogDataContext>();
            services.AddScoped<IGetAuditLogsByActionDataContext, InMemoryGetAuditLogsByActionDataContext>();
            services.AddScoped<IGetAllAuditLogsDataContext, InMemoryGetAllAuditLogsDataContext>();
            services.AddScoped<IGetAuditLogsByEntityIdDataContext, InMemoryGetAuditLogsByEntityIdDataContext>();

            services.AddScoped<IRegisterCustomerFeedbackDataContext, InMemoryRegisterCustomerFeedbackDataContext>();
            services.AddScoped<IGetAllCustomerFeedbackDataContext, InMemoryGetAllCustomerFeedbackDataContext>();
            services.AddScoped<IGetCustomerFeedbackByEntityIdDataContext, InMemoryGetCustomerFeedbackByEntityIdDataContext>();
            services.AddScoped<IGetCustomerFeedbackByCustomerIdDataContext, InMemoryGetCustomerFeedbackByCustomerIdDataContext>();
            services.AddScoped<IGetCustomerFeedbackByRatingDataContext, InMemoryGetCustomerFeedbackByRatingDataContext>();

            services.AddScoped<IRegisterIncidentReportDataContext, InMemoryRegisterIncidentReportDataContext>();

            services.AddScoped<IRegisterNonConformityDataContext, InMemoryRegisterNonConformityDataContext>();
            services.AddScoped<IRegisterNonCormityDetailDataContext, InMemoryRegisterNonConformityDetailDataContext>();
            services.AddScoped<IGetAllNonConformitiesDataContext, InMemoryGetAllNonConformitiesDataContext>();
            services.AddScoped<IGetNonConformityByAffectedProcessDataContext, InMemoryGetNonConformityByAffectedProcessDataContext>();
            services.AddScoped<IGetNonConformityByEntityIdDataContext, InMemoryGetNonConformityByEntityIdDataContext>();
            services.AddScoped<IGetNonConformityByStatusDataContext, InMemoryGetNonConformityByStatusDataContext>();

            return services;
        }
    }
}
