using BIMPlatform.ProjectDataInfo;
using BIMPlatform.ProjectService;
using Microsoft.AspNetCore.Mvc;
using Platform.ToolKits.Base;
using Platform.ToolKits.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.Controllers.Project
{
    public class ProjectController : BaseController
    {
        private  IProjectService ProjectService { get; set; }
     
        public ProjectController(IProjectService projectService)
        {
            ProjectService = projectService;
        }
       
        [HttpGet]
        public async Task<ServiceResult> GetProject(Guid id)
        {
            var project = await ProjectService.GetProjectAsync(id);
            return await ServiceResult<ProjectDto>.IsSuccess(project);
        }
        [HttpGet]
        public async Task<ServiceResult> GetProjectsByTenant(Guid id)
        {
            var project = await ProjectService.GetProjectsByTenantAsync(id);
            return await ServiceResult<IList<ProjectDto>>.IsSuccess(project);
        }
        /// <summary>
        /// 获取当前租户下的所有项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult> GetProjects()
        {
            var project = await ProjectService.GetProjectsByTenantAsync();
            return await ServiceResult<IList<ProjectDto>>.IsSuccess(project);
        }
        [HttpGet]
        public async Task<ServiceResult> QueryProjects(Guid tenantID, string name)
        {
            var project = await ProjectService.QueryProjects(tenantID,name);
            return await ServiceResult<IList<ProjectDto>>.IsSuccess(project);
        }
        [HttpPost]
        public async Task<ServiceResult> Create(ProjectCreateParams createParams)
        {
            await ProjectService.CreateAsync(createParams);
            return await ServiceResult.IsSuccess();
        }

        [HttpPut]
        public async Task<ServiceResult> Update(ProjectDto projectDto)
        {
            await ProjectService.UpdateAsync(projectDto);
            return await ServiceResult.IsSuccess();
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(Guid id)
        {
            await ProjectService.DeleteAsync(id);
            return await ServiceResult.IsSuccess();
        }
    }
}
