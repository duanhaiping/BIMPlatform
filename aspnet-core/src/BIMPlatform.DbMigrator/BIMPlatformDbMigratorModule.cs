using BIMPlatform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BIMPlatform.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BIMPlatformEntityFrameworkCoreDbMigrationsModule),
        typeof(BIMPlatformApplicationContractsModule)
        )]
    public class BIMPlatformDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
