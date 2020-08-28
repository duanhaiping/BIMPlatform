using Volo.Abp.Modularity;

namespace BIMPlatform
{
    [DependsOn(
        typeof(BIMPlatformApplicationModule),
        typeof(BIMPlatformDomainTestModule)
        )]
    public class BIMPlatformApplicationTestModule : AbpModule
    {

    }
}