using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BIMPlatform.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        //typeof(BIMPlatformHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BIMPlatformConsoleApiClientModule : AbpModule
    {
        
    }
}
