namespace ISO9001.NonConformity.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddNonConformityCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGetAllNonConformitiesInputPort, GetAllNonConformitiesHandler>();
            services.AddScoped<IGetNonConformityByAffectedProcessInputPort, GetNonConformityByAffectedProcessHandler>();
            services.AddScoped<IGetNonConformityByEntityIdInputPort, GetNonConformityByEntityIdHandler>();
            services.AddScoped<IGetNonConformityByStatusInputPort, GetNonConformityByStatusHandler>();
            services.AddScoped<IRegisterNonConformityInputPort, RegisterNonConformityHandler>();
            services.AddScoped<IRegisterNonConformityDetailInputPort, RegisterNonConformityDetailHandler>();
            return services;
        }
    }

}
