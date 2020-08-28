using System;
using Volo.Abp.Domain.Repositories;

namespace BIMPlatform.Project.Repositories
{
    public interface IProjectRepository : IRepository<Projects.Project,Guid>
    {
    }
}
