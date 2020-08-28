using System.Threading.Tasks;

namespace BIMPlatform.Data
{
    public interface IBIMPlatformDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
