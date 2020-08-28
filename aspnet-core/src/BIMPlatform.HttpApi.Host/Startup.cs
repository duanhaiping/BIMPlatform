using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BIMPlatform
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            Volo.Abp.PermissionManagement.AbpPermissionManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.SettingManagement.AbpSettingManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.TenantManagement.AbpTenantManagementDbProperties.DbTablePrefix = "Tnt_";
            Volo.Abp.Identity.AbpIdentityDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.IdentityServer.AbpIdentityServerDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.FeatureManagement.FeatureManagementDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.BackgroundJobs.BackgroundJobsDbProperties.DbTablePrefix = "Sys_";
            Volo.Abp.AuditLogging.AbpAuditLoggingDbProperties.DbTablePrefix = "SysLog_";
            
            services.AddApplication<BIMPlatformHttpApiHostModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
