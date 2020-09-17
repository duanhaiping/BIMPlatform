using BIMPlatform.Application.Contracts.OSS;
using BIMPlatform.OSSService;
using Microsoft.AspNetCore.Mvc;
using Platform.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.Controllers.OSS
{
    [ApiExplorerSettings(GroupName = ApiGrouping.GroupName_v1)]
    public class OssController : BaseController
    {
        private IOssService OssService { get; set; }
        public OssController(IOssService ossService)
        {
            this.OssService = ossService;
        }
        /// <summary>
        /// 获取oss 上传策略
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ServiceResult> Policy()
        {
            var policy = await OssService.Policy();
            return await ServiceResult<OssPolicyResult>.IsSuccess(policy);
        }
        /// <summary>
        ///  回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ServiceResult> Callback()
        {
            var callback = await OssService.Callback(this.HttpContext.Request);
            return await ServiceResult<OssCallbackResult>.IsSuccess(callback);
        }
    }
}
