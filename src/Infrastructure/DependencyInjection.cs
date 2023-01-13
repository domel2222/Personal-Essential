namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IWeightFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<IActiveFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<ISessionFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJournalRepository, JournalRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISelfAssessmentValueRepository, SelfAssessmentValueRepository>();
            services.AddScoped<IMostWinDuringTheDayRepository, MostWinDuringTheDayRepository>();
            
            return services;
        }
    }
}
