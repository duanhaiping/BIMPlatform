using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.MinIO
{
    public class MinioUploadDto
    {
        /// <summary>
        ///  file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }
    }
}
