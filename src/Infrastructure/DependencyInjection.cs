namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IWeightFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<IActiveFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<ISessionFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
