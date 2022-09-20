using BlazorTickets.App.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Net.Http.Headers;
using NLog;
using NLog.Web;
using Radzen;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
    builder.Services.AddAuthorization(options =>
    {
        // By default, all incoming requests will be authorized according to the default policy.
        options.FallbackPolicy = options.DefaultPolicy;
    });

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddCors(options => { 
        options.AddPolicy("NewPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
    builder.Services.AddHttpClient("Default", options => {
        options.BaseAddress = new Uri(configuration.GetValue<string>("WebApis:Default"));
        options.DefaultRequestHeaders.Clear();
        options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    });

    builder.Services.AddSingleton<ActiveDirectoryService>();
    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }

    app.UseStaticFiles();
    app.UseRouting();
    app.UseCors("NewPolicy");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
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