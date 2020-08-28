using BIMPlatform.Project.Repositories;
using BIMPlatform.ProjectDataInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace BIMPlatform.ProjectService.impl
{
    public class ProjectService : BaseService, IProjectService
    {
        private readonly IProjectRepository ProjectRepository;
       
        private readonly IDataFilter DataFilter;
        public ProjectService(IProjectRepository projectRepository, IDataFilter dataFilter)
        {
           
            DataFilter = dataFilter;
            ProjectRepository = projectRepository;
        } 
        public Task CreateAsync(ProjectCreateParams projectDto)
        {
            Projects.Project project = ObjectMapper.Map<ProjectCreateParams, Projects.Project>(projectDto);
            project.CreationTime = DateTime.Now;
            project.CreatorId = CurrentUser.Id;
            project.TenantId = CurrentTenant.Id;
            project.IsDeleted = false;
            var existed=  ProjectRepository.FirstOrDefault(c=>c.Name==project.Name &&c.TenantId== project.TenantId);
            if (existed != null)
                throw new ArgumentException(L["ProjectError:NameDuplicate"]);
            ProjectRepository.InsertAsync(project);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid projectID)
        {
            Projects.Project project = await ProjectRepository.FindAsync(c => c.Id==projectID);
            //project.IsDeleted=true;
            await ProjectRepository.UpdateAsync(project);
            
        }
       
        public async  Task<ProjectDto> GetProjectAsync(Guid projectID)
        {
            Projects.Project project = await ProjectRepository.FindAsync(c => c.Id == projectID);
            return ObjectMapper.Map<Projects.Project, ProjectDto>(project);
        }

        public async Task<IList<ProjectDto>> GetProjectsByTenantAsync(Guid tenantID)
        {
            IList<ProjectDto> result;
            using (DataFilter.Enable<IMultiTenant>())
            {
                var target = await ProjectRepository.GetListAsync();
                result =ObjectMapper.Map<IList< Projects.Project> ,IList< ProjectDto >> (target);
                return result;
            }
        }
        public async Task<IList<ProjectDto>> GetProjectsByTenantAsync()
        {
            IList<ProjectDto> result;
            using (DataFilter.Enable<IMultiTenant>())
            {
                var target = (await ProjectRepository.GetListAsync()).WhereIf(true,c=>c.IsDeleted==false).ToList();
                result = ObjectMapper.Map<IList<Projects.Project>, IList<ProjectDto>>(target);
                return result;
            }
        }
        public async Task<IList<ProjectDto>> QueryProjects( string name)
        {
            IList<ProjectDto> result;
            using (DataFilter.Enable<IMultiTenant>())
            {
                var target = (await ProjectRepository.GetListAsync()).WhereIf(!string.IsNullOrWhiteSpace(name),c=>c.Name== name && c.IsDeleted==false).ToList();
                result = ObjectMapper.Map<IList<Projects.Project>, IList<ProjectDto>>(target);
                return result;
            }
        }
        public Task UpdateAsync(ProjectDto projectDto)
        {
            throw new NotImplementedException();
        }

        
    }
}
