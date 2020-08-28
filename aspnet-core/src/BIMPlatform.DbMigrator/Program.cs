using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BIMPlatform.DbMigrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
#if DEBUG
                .MinimumLevel.Override("BIMPlatform", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("BIMPlatform", LogEventLevel.Information)
#endif
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/logs.txt"))
                .WriteTo.Console()
                .CreateLogger();
            Volo.Abp.PermissionManagement.AbpPermissionManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.SettingManagement.AbpSettingManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.TenantManagement.AbpTenantManagementDbProperties.DbTablePrefix = "Tnt_";
            Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.FeatureManagement.FeatureManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.BackgroundJobs.BackgroundJobsDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.AuditLogging.AbpAuditLoggingDbProperties.DbTablePrefix = "SysLog_";
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => logging.ClearProviders())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });
    }
}
