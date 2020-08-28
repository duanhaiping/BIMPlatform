using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Platform.ToolKits.Base;

namespace BIMPlatform.Filters
{
    public class BIMPlatformExceptionFilter : IExceptionFilter
    {
        private readonly ILog _log;

        public BIMPlatformExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(BIMPlatformExceptionFilter));
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
            context.Result = new JsonResult(ServiceResult.IsFailed(context.Exception.Message));
            context.ExceptionHandled = true;
        }
    }
}
