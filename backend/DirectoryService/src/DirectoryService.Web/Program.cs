using DirectoryService.Core.Locations;
using Scalar.AspNetCore;
using DirectoryService.Infrastructure.Postgres;
using DirectoryService.Infrastructure.Postgres.Database;
using DirectoryService.Infrastructure.Postgres.Repositories;
using DirectoryService.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IDbConnectionFactory, NpgSqlConnectionFactory>();


#pragma warning disable S125
builder.Services.AddScoped<ILocationsRepository, NpgSqlLocationsRepository>();
#pragma warning restore S125

#pragma warning disable S125
//builder.Services.AddScoped<ILocationsRepository, EfCoreLocationsRepository>();
#pragma warning restore S125

builder.Services.AddProgramDependencies();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", () => $"crm-platform in development");

app.MapControllers();

app.MapHealthChecks("/api/health");

if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await app.RunAsync();