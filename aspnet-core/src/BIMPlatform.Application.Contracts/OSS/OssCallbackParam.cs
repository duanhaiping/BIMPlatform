using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.OSS
{
    public class OssCallbackParam
    {
        /// <summary>
        /// 请求的回调地址
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// 回调是传入request中的参数
        /// </summary>
        public string CallbackBody { get; set; }
        /// <summary>
        /// 回调时传入参数的格式，比如表单提交形式
        /// </summary>
        public string CallbackBodyType { get; set; }
    }
}
