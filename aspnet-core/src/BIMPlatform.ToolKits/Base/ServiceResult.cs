using Platform.ToolKits.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Platform.ToolKits.Base
{
    public class ServiceResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success => Code == ServiceResultCode.Succeed;
      
        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        //public void IsSuccess( string message = "")
        //{
        //    Message = message;
        //    Code = ServiceResultCode.Succeed;
          
        //}
        public static async Task<ServiceResult> IsSuccess( string message = "")
        {
            ServiceResult serviceResult = new ServiceResult
            {
                Message = message,
                Code = ServiceResultCode.Succeed
            };
            //serviceResult.IsSuccessIn(result);
            return await Task.FromResult(serviceResult);
        }
        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<ServiceResult> IsFailed(string message = "")
        {
            ServiceResult serviceResult = new ServiceResult
            {
                Message = message,
                Code = ServiceResultCode.Failed
            };
            return await Task.FromResult(serviceResult);
           
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exexception></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<ServiceResult> IsFailed(Exception exception)
        {
            ServiceResult serviceResult = new ServiceResult
            {
                Message = exception.InnerException?.StackTrace,
                Code = ServiceResultCode.Failed
            };
            return await Task.FromResult(serviceResult);
          
        }
    }
}
