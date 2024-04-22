using Microsoft.OpenApi.Models;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistence;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.API.Extensions;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.API;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureCorsPolicy();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Users API",
        Description = "Minimal API implemented with Clean Architecture",
        Version = "v1",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "Users API V1");
    });
    app.UseCors();
}

app.RegisterEndpoints();
app.UseHttpsRedirection();
MigrateDatabase(app);
app.Run();

static void MigrateDatabase(IApplicationBuilder app)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ocorreu um erro na migração/alimentação dos dados");
        }
    }
}