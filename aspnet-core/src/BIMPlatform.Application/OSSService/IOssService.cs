using BIMPlatform.Application.Contracts.OSS;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BIMPlatform.OSSService
{
    public interface IOssService
    {
        /// <summary>
        /// oss上传策略生成
        /// </summary>
        /// <returns></returns>
         Task< OssPolicyResult> Policy();

        /// <summary>
        /// oss上传成功回调 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OssCallbackResult> Callback(HttpRequest request);
    }
}
