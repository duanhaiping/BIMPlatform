using BIMPlatform.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BIMPlatform
{
    [DependsOn(
        typeof(BIMPlatformEntityFrameworkCoreTestModule)
        )]
    public class BIMPlatformDomainTestModule : AbpModule
    {

    }
}