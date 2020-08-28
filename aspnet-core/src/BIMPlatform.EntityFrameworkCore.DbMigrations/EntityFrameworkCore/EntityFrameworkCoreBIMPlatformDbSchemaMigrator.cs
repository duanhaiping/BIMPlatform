using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BIMPlatform.Data;
using Volo.Abp.DependencyInjection;

namespace BIMPlatform.EntityFrameworkCore
{
    public class EntityFrameworkCoreBIMPlatformDbSchemaMigrator
        : IBIMPlatformDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBIMPlatformDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BIMPlatformMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BIMPlatformMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}