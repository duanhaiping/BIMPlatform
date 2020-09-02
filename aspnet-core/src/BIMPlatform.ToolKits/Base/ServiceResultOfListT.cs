using Platform.ToolKits.Base;
using Platform.ToolKits.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.ToolKits.Base
{
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public IList<T> Result { get; set; }

        public int Total { get; set; }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void IsSuccessIn(IList<T> result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }
        public static async Task<ServiceResult> IsSuccess(IList<T> result = null, string message = "")
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>
            {
                Message = message,
                Code = ServiceResultCode.Succeed,
                Result = result
            };
            serviceResult.IsSuccessIn(result);
            return await Task.FromResult(serviceResult);
        }

        public static async Task<ServiceResult> PageList(IList<T> result, int total, string message = "")
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>
            {
                Message = message,
                Code = ServiceResultCode.Succeed,
                Result = result,
                Total=total,
            };
            serviceResult.IsSuccessIn(result);
            return await Task.FromResult(serviceResult);
        }
    }
}
