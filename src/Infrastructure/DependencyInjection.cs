﻿using Application.Common.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Repositories;
using Infrastructure.Persistence.Repositories;

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

            return services;
        }
    }
}