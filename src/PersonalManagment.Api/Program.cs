
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
builder.Services.AddControllers();

// dependency injection 
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddSwaggerGen(c =>
{
    string presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

    string presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

    c.IncludeXmlComments(presentationDocumentationFilePath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Personal Essential Tracker", Version = "v1" });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<PersonalDbContext>(
    option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("PersonalEssential"))
    );

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
