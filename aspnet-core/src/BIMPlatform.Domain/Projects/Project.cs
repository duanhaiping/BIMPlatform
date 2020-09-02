using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BIMPlatform.Projects
{
    public class Project : Entity<Guid>, IAuditedObject, ISoftDelete, IDeletionAuditedObject, IMultiTenant
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
        public string ConsultingUnit { get; set; }
        public float Area { get; set; }
        public Guid Principal { get; set; }
        public DateTime CompleteDate { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public DateTime CreationTime { get ; set ; }
        public Guid? CreatorId { get ; set ; }
        public Guid? LastModifierId { get ; set ; }
        public DateTime? LastModificationTime { get ; set ; }
        public bool IsDeleted { get ; set ; }
        public Guid? DeleterId { get ; set ; }
        public DateTime? DeletionTime { get ; set ; }
        public Guid? TenantId { get; set; }
      
    }
}
