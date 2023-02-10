namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorSecond<,>));
            services.AddTransient<IValidator<CreateJournalCommand>, CreateJournalCommandValidator>();
            services.AddTransient<IValidator<DeleteJournalCommand>, DeleteJournalCommandValidator>();
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviorPipeline<,>));
            //services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehavior<>));

            //Mapster settings
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
    }
}
