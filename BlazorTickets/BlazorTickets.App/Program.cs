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
    IConfigurationRoot config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Administrators", policy => policy.RequireRole(config.GetSection("Security:Policies:Administrators").Get<string[]>()));
        options.FallbackPolicy = options.DefaultPolicy;
    });

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddCors(options => { 
        options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });

    builder.Services.AddHttpClient("Default", options => {
        options.BaseAddress = new Uri(config.GetValue<string>("WebApis:Default"));
        options.DefaultRequestHeaders.Clear();
        options.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    });

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();
    builder.Services.AddSingleton<ActiveDirectoryService>();

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