
using BIMPlatform.Application.Contracts;
using BIMPlatform.Application.Contracts.ProjectDataInfo;
using BIMPlatform.ProjectDataInfo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BIMPlatform.ProjectService
{
    public interface IProjectService 
    {
        Task<PagedResultDto<ProjectDto>> GetProjects(BasePagedAndSortedResultRequestDto filter);
        Task<ProjectDto> GetProjectAsync(Guid projectID);
        Task CreateAsync(ProjectCreateParams projectDto);
        Task<ProjectDto> UpdateAsync(ProjectUpdateParams projectDto);
        Task DeleteAsync(Guid projectID);
    }
}
