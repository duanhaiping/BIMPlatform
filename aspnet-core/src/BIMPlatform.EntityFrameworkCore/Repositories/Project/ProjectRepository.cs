using BIMPlatform.EntityFrameworkCore;
using BIMPlatform.Project.Repositories;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BIMPlatform.Repositories.Project
{
    public class ProjectRepository : EfCoreRepository<BIMPlatformDbContext,Projects.Project, Guid>, IProjectRepository
    {
        public ProjectRepository(IDbContextProvider<BIMPlatformDbContext> dbContextProvider) : base(dbContextProvider)
        {
           
        }
        
        //public override Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
        //{

        //    return base.DeleteAsync(id, autoSave, cancellationToken);
        //}
    }
}
