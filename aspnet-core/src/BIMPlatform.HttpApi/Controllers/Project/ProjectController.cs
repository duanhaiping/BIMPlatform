using BIMPlatform.Application.Contracts;
using BIMPlatform.Application.Contracts.Project;
using BIMPlatform.ProjectService;
using Microsoft.AspNetCore.Mvc;
using Platform.ToolKits.Base;
using Platform.ToolKits.Base.Enum;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.Controllers.Project
{

    public class ProjectController : BaseController
    {
        private IProjectService ProjectService { get; set; }

        public ProjectController(IProjectService projectService)
        {
            ProjectService = projectService;
        }
        /// <summary>
        /// 获取id 所代表的项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(200, "", typeof(ServiceResult<ProjectDto>))]
        public async Task<ServiceResult> GetProject(Guid id)
        {
            var project = await ProjectService.GetProjectAsync(id);
            return await ServiceResult<ProjectDto>.IsSuccess(project);
        }
        /// <summary>
        /// 获取当前租户下的所有项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, "", typeof(ServiceResult<IList<ProjectDto>>))]
        public async Task<ServiceResult> GetProjects([FromQuery]BasePagedAndSortedResultRequestDto filter)
        {
            var project = await ProjectService.GetProjects(filter);
            return await ServiceResult<IList<ProjectDto>>.PageList(project.Items.ToList(), project.TotalCount, string.Empty);
        }
        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="createParams">具体参数参考实体类型说明</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ServiceResult> Create([FromBody]ProjectCreateParam createParams)
        {
            await ProjectService.CreateAsync(createParams);
            return await ServiceResult.IsSuccess();
        }
        /// <summary>
        /// 更新项目
        /// </summary>
        /// <param name="updateParams">具体参数参考实体类型说明</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ServiceResult> Update([FromBody]ProjectUpdateParam updateParams)
        {
            await ProjectService.UpdateAsync(updateParams);
            return await ServiceResult.IsSuccess();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ServiceResult> Delete([FromServices]Guid id)
        {
            await ProjectService.DeleteAsync(id);
            return await ServiceResult.IsSuccess();
        }
    }
}
