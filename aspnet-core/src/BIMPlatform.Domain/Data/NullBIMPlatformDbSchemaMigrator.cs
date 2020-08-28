using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BIMPlatform.Data
{
    /* This is used if database provider does't define
     * IBIMPlatformDbSchemaMigrator implementation.
     */
    public class NullBIMPlatformDbSchemaMigrator : IBIMPlatformDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}