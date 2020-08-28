using BIMPlatform.MultiTenancy;
using BIMPlatform.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace BIMPlatform.EntityFrameworkCore
{
    public static class BIMPlatformDbContextModelCreatingExtensions
    {
        public static void ConfigureBIMPlatform(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Projects.Project>(b =>
            {
                b.ToTable(BIMPlatformConsts.DbTablePrefix_Project + "Project");
                b.Property(x => x.Description).HasMaxLength(200);
                b.Property(x => x.Name).HasMaxLength(100).IsRequired();
                b.Property(x => x.IsDeleted).HasDefaultValue(false);
            });
          
        }
    }
}