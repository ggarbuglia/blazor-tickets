// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

using BlazorTickets.Data;
using BlazorTickets.Domain.Contracts;
using BlazorTickets.WebApi.Helpers;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NLog;
using NLog.Web;
using System.Reflection;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

    var cnn = configuration.GetConnectionString("Default");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(cnn));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddControllers();

    builder.Services.AddHealthChecks()
        .AddSqlServer(cnn)
        .AddDbContextCheck<DatabaseContext>()
        .AddCheck<HealthCheck>("Check");

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthorization();
    app.MapControllers();

    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        AllowCachingResponses = false,
        ResultStatusCodes = 
        {
            [HealthStatus.Healthy]   = StatusCodes.Status200OK,
            [HealthStatus.Degraded]  = StatusCodes.Status200OK,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
        }
    });

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}