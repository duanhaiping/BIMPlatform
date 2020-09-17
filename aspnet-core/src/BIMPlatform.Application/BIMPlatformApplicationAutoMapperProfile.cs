using AutoMapper;
using BIMPlatform.Application.Contracts.Project;

namespace BIMPlatform
{
    public class BIMPlatformApplicationAutoMapperProfile : Profile
    {
        public BIMPlatformApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Projects.Project, ProjectDto>();
            CreateMap< ProjectDto, Projects.Project>();
            CreateMap<ProjectCreateParam, Projects.Project>();
        }
    }
}
