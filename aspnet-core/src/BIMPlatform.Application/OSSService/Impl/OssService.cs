using Aliyun.OSS;
using BIMPlatform.Application.Contracts.OSS;
using BIMPlatform.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Platform.ToolKits.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.OSSService.Impl
{
    public class OssService : BaseService, IOssService
    {

        public async Task<OssCallbackResult> Callback(HttpRequest request)
        {
            OssCallbackResult result = new OssCallbackResult();
            String filename = request.Query["filename"];
            filename = "http://"+(AppSettings.ALiYun.BucketName)+(".")+(AppSettings.ALiYun.EndPoint) +("/")+(filename);
            result.FileName = filename;
            result.Size= request.Query["size"];
            result.MineType=request.Query["mimeType"];
            result.Width = request.Query["width"];
            result.Height = request.Query["height"];
            return result;
        }

        public async Task<OssPolicyResult> Policy()
        {
            OssPolicyResult result = new OssPolicyResult();
            string dir = AppSettings.ALiYun.DirPrefix+ DateTime.Now.ToString("yyyyMMdd");
            //long expireEndTime =DateTime.Now.Millisecond + AppSettings.ALiYun.Expire * 1000;
            DateTime expiration = DateTime.Now.AddMilliseconds(AppSettings.ALiYun.Expire * 1000);
            long maxSize = AppSettings.ALiYun.MaxSize * 1024 * 1024;
            OssCallbackParam callback = new OssCallbackParam();
            callback.CallbackUrl=AppSettings.ALiYun.Callback;
            callback.CallbackBody = "filename=${object}&size=${size}&mimeType=${mimeType}&height=${imageInfo.height}&width=${imageInfo.width}" ;
            callback.CallbackBodyType="application/x-www-form-urlencoded";
            string  action = "http://" + AppSettings.ALiYun.BucketName + "." + AppSettings.ALiYun.EndPoint;
            try
            {
                PolicyConditions policyConds = new PolicyConditions();
                policyConds.AddConditionItem(PolicyConditions.CondContentLengthRange, 0, maxSize);
                policyConds.AddConditionItem(MatchMode.StartWith, PolicyConditions.CondKey, dir);
                OssClient ossClient = new OssClient(action, AppSettings.ALiYun.AccessKeyId, AppSettings.ALiYun.AccessKeySecret);
                string postPolicy = ossClient.GeneratePostPolicy(expiration, policyConds);
                byte[] binaryData = postPolicy.GetBytes(Encoding.UTF8);
                string policy =Convert.ToBase64String (binaryData);
                string signature = ComputeSignature(AppSettings.ALiYun.AccessKeySecret, policy);
                string callbackData = Convert.ToBase64String(callback.ToJson().ToString().GetBytes(Encoding.UTF8));
                // 返回结果
                result.AccessKeyId = AppSettings.ALiYun.AccessKeyId;
                result.Policy=policy;
                result.Signature=signature;
                result.Dir= dir;
                result.Callback=callbackData;
                result.Host= action;
            }
            catch (Exception e)
            {
                Logger.Log(LogLevel.Error,"签名生成失败", e);
            }
            return result;
        }
        private static string ComputeSignature(string key, string data)
        {
            using (var algorithm = KeyedHashAlgorithm.Create("HmacSHA1".ToUpperInvariant()))
            {
                algorithm.Key = Encoding.UTF8.GetBytes(key.ToCharArray());
                return Convert.ToBase64String(
                    algorithm.ComputeHash(Encoding.UTF8.GetBytes(data.ToCharArray())));
            }
        }
    }
}
