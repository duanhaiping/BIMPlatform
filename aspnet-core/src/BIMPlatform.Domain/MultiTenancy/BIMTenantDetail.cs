using System;
using Volo.Abp.Domain.Entities;

namespace BIMPlatform.MultiTenancy
{
    public class BIMTenantDetail : Entity<Guid>
    {
        public string Abbreviation { get; set; }
        public string RegisterNo { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public bool IsDeleted { get ; set ; }
        public Guid TenantId { get ; set ; }
        public long? CreatorUserId { get ; set; }
        public DateTime CreationTime { get; set ; }
        public long? LastModifierUserId { get; set ; }
        public DateTime? LastModificationTime { get ; set ; }
        public long? DeleterUserId { get ; set; }
        public DateTime? DeletionTime { get ; set ; }
    }
}
