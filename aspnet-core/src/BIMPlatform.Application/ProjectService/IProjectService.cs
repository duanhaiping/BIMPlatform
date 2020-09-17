
using BIMPlatform.Application.Contracts;
using BIMPlatform.Application.Contracts.Project;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BIMPlatform.ProjectService
{
    public interface IProjectService 
    {
        Task<PagedResultDto<ProjectDto>> GetProjects(BasePagedAndSortedResultRequestDto filter);
        Task<IList<ProjectDto>> GetProjectList(string name);
        Task<ProjectDto> GetProjectAsync(Guid projectID);
        Task CreateAsync(ProjectCreateParam projectDto);
        Task<ProjectDto> UpdateAsync(ProjectUpdateParam projectDto);
        Task DeleteAsync(Guid projectID);
    }
}
