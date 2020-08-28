using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BIMPlatform.ProjectDataInfo
{
    public class ProjectDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
        public decimal ProjectEstimate { get; set; }
        public string ConstructionUnit { get; set; }
        public string MainContractor { get; set; }
        public string DesignOrganization { get; set; }
        public string SupervisingUnit { get; set; }
        public string ConstructionUnits { get; set; }
        public DateTime CompleteDate { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string LaunchUser { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }

        public Guid? TenantId { get; set; }
    }
}
