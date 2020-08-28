using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BIMPlatform.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class BIMPlatformMigrationsDbContextFactory : IDesignTimeDbContextFactory<BIMPlatformMigrationsDbContext>
    {
        public BIMPlatformMigrationsDbContext CreateDbContext(string[] args)
        {
            BIMPlatformEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BIMPlatformMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new BIMPlatformMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
