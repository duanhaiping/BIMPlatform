using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.OSS
{
    public class OssCallbackResult
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 文件的mimeType
        /// </summary>
        public string MineType { get; set; }
        /// <summary>
        /// 图片文件的宽
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 图片文件的高
        /// </summary>
        public string Height { get; set; }
    }
}
