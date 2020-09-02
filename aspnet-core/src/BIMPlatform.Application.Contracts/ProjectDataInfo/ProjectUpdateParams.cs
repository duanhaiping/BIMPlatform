using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIMPlatform.Application.Contracts.ProjectDataInfo
{
    public class ProjectUpdateParams
    {
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        ///  名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(100)]
        public string Address { get; set; }
        /// <summary>
        /// 项目概算
        /// </summary>
        [Range(0, 99999999999.999)]
        public decimal ProjectEstimate { get; set; }
        /// <summary>
        /// 施工单位
        /// </summary>
        [StringLength(100)]
        public string ConstructionUnit { get; set; }
        /// <summary>
        /// 总包
        /// </summary>
        [StringLength(100)]
        public string MainContractor { get; set; }
        /// <summary>
        /// 设计单位
        /// </summary>
        [StringLength(100)]
        public string DesignOrganization { get; set; }
        /// <summary>
        /// 监理单位
        /// </summary>
        [StringLength(100)]
        public string SupervisingUnit { get; set; }
        /// <summary>
        /// 咨询单位
        /// </summary>
        [StringLength(100)]
        public string ConsultingUnit { get; set; }
        [Range(0, 999999999.99)]
        public float Area { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompleteDate { get; set; }
        [Range(0, 9999.999)]
        public float Longitude { get; set; }
        [Range(0, 9999.999)]
        public float Latitude { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public Guid Principal { get; set; }
    }
}
