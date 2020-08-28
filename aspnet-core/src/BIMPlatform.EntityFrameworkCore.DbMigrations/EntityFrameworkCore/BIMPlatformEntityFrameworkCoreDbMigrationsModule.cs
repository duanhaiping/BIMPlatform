using BIMPlatform.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace BIMPlatform.EntityFrameworkCore
{
    [DependsOn(
        typeof(BIMPlatformEntityFrameworkCoreModule)
        )]
    public class BIMPlatformEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.RemoveAll(t => t.ImplementationType == typeof(IDataSeedContributor));
            //context.Services.AddTransient<IDataSeedContributor, BIMPlatformAdministratorUserDataSeederContributor>();
            context.Services.AddAbpDbContext<BIMPlatformMigrationsDbContext>();
        }
    }
}
