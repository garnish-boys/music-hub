using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.IdentityServer.Config;
using MusicHub.IdentityServer.Data;
using MusicHub.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

//Configure the Serilog logging
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

var identityDbStr = builder.Configuration.GetConnectionString("IdentityDb");
var identityConfigDbStr = builder.Configuration.GetConnectionString("IdentityConfigurationDb");

var serverVersion = new MySqlServerVersion(new Version(10, 6, 7));

//COnfigure host process to use serilog
builder.Host.UseSerilog();

// Add necessary services for MVC to function
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Register DbContext for access to db using Sql Server and the
// connection string labelled "Default" in appsettings.json
builder.Services.AddDbContext<MusicHubDbContext>(
    opt => opt.UseMySql(identityDbStr, serverVersion));

// Setup Identity services - configure EF core stores
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<MusicHubDbContext>()
    .AddDefaultTokenProviders();

// Need to tell Identity Server storage which assembly to 
// reference when looking for/applying db migration - see Migrations folder (has model snapshot, etc.)
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

// Create and configure Identity Server builder
var idServBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddConfigurationStore<IdentityConfigDbContext>(opt =>
    {
        opt.ConfigureDbContext = builder =>
            builder.UseMySql(identityConfigDbStr, serverVersion, opt => 
                opt.MigrationsAssembly(migrationsAssembly));
    })
    //.AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources) //IdentityServerConfig has all of the configuration
    //.AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
    //.AddInMemoryClients(IdentityServerConfig.Clients)
    .AddAspNetIdentity<User>();

builder.Services.AddAuthentication();

//App gets built first bc middleware gets access to DI services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();