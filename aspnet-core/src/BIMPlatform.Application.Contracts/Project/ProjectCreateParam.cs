using System;
using System.ComponentModel.DataAnnotations;

namespace BIMPlatform.Application.Contracts.Project
{
    /*
     * 兼容ASP.NET Core模型验证系统
     * ASP.NET Core 内置特性：
     * [CreditCard]：验证属性是否具有信用卡格式。 需要 JQuery 验证其他方法。
     * [Compare]：验证模型中的两个属性是否匹配。
     * [EmailAddress]：验证属性是否具有电子邮件格式。
     * [Phone]：验证属性是否具有电话号码格式。
     * [Range]：验证属性值是否在指定的范围内。
     * [RegularExpression]：验证属性值是否与指定的正则表达式匹配。
     * [Required]：验证字段是否不为 null。
     * [StringLength]：验证字符串属性值是否不超过指定长度限制
     * [Url]：验证属性是否具有 URL 格式
     * [Remote]：通过在服务器上调用操作方法来验证客户端上的输入
     */
    public class ProjectCreateParam
    {
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
        [Range(0,99999999999.999)]
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
        [Range(0,999999999.99)]
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
