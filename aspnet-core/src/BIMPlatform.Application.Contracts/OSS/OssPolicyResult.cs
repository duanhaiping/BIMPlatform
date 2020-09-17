using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.OSS
{
    /**
  * 获取OSS上传文件授权返回结果
  * Created by macro on 2018/5/17.
  */
    public class OssPolicyResult
    {
        /// <summary>
        /// 访问身份验证中用到用户标识
        /// </summary>
        public string AccessKeyId { get; set; }
        /// <summary>
        /// 用户表单上传的策略,经过base64编码过的字符串
        /// </summary>
        public string Policy { get; set; }
        /// <summary>
        /// 对policy签名后的字符串
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 上传文件夹路径前缀
        /// </summary>
        public string Dir { get; set; }
        /// <summary>
        /// oss对外服务的访问域名
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        ///  上传成功后的回调设置
        /// </summary>
        public string Callback { get; set; }

     
    }
}
