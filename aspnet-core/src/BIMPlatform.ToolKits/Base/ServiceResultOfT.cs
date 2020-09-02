using Platform.ToolKits.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Platform.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体(泛型)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        public long Total { get; set; }
        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public void IsSuccessIn(T result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }

      
        public static async Task<ServiceResult> IsSuccess(T result = null, string message = "")
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
        public static async Task<ServiceResult> PageList(T result, long total, string message = "")
        {
            ServiceResult<T> serviceResult = new ServiceResult<T>
            {
                Message = message,
                Code = ServiceResultCode.Succeed,
                Result = result,
                Total = total,
            };
            serviceResult.IsSuccessIn(result);
            return await Task.FromResult(serviceResult);
        }
    }
}
