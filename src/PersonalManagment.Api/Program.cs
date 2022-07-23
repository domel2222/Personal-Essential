using Application.Common.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IWeightFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
builder.Services.AddScoped<IActiveFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
