using Application.Common.Interfaces;
using Infrastructure.ExternalAPI.GoogleFIT;
using Infrastructure.ExternalAPI.GoogleFIT.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

//builder.Services.AddControllers().AddApplicationPart(presentationAssembly);


//builder.Services.AddSwaggerGen(c =>
//{
//    string presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

//    string presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

//    c.IncludeXmlComments(presentationDocumentationFilePath);

//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalEssential", Version = "v1" });
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IWeightFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
builder.Services.AddScoped<IActiveFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
builder.Services.AddScoped<ISessionFitnessGoogleApi, FitnessGoogleConnectionInitializer>();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//builder.Services.AddDbContext<PersonalDbContext>(
//    option =>
//    option.UseSqlServer(builder.Configuration.GetConnectionString("PersonalEssential"))
//    );

builder.Services.AddCors(options => options.AddPolicy(name: "PersonalEssentialOrigins",
        policy =>
        {
            policy.WithOrigins(builder.Configuration["AllowedOrigins"])
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PersonalEssentialOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
