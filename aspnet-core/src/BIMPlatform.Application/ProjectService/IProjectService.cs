
using BIMPlatform.ProjectDataInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BIMPlatform.ProjectService
{
    public interface IProjectService 
    {
        Task<IList<ProjectDto> > GetProjectsByTenantAsync(Guid tenantID);
        Task<IList<ProjectDto>> GetProjectsByTenantAsync();
        Task<IList<ProjectDto>> QueryProjects(string name);
        Task<ProjectDto> GetProjectAsync(Guid projectID);
        Task CreateAsync(ProjectCreateParams projectDto);
        Task UpdateAsync(ProjectDto projectDto);
        Task DeleteAsync(Guid projectID);
    }
}
