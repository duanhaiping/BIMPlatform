using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace BIMPlatform.Configurations
{
    public class AppSettings
    {
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot _config;

        private const string Prefix = "BIMPlatform";

        /// <summary>
        /// Constructor
        /// </summary>
        static AppSettings()
        {
            // 加载appsettings.json，并构建IConfigurationRoot
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", true, true);
            _config = builder.Build();
        }

        /// <summary>
        /// EnableDb
        /// </summary>
        public static string EnableDb => _config["ConnectionStrings:Enable"];

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        public static string ConnectionStrings => _config.GetConnectionString("Default");

        public static string ApiVersion => _config["ApiVersion"];

        public static class Hangfire
        {
            public static string Login => _config["Hangfire:Login"];
            public static string Password => _config["Hangfire:Password"];
        }
        public static class ALiYun
        {
            public static string EndPoint => _config["ALiYun:OSS:EndPoint"];
            public static string AccessKeyId => _config["ALiYun:OSS:AccessKeyId"];
            public static string AccessKeySecret => _config["ALiYun:OSS:AccessKeySecret"];
            public static string BucketName => _config["ALiYun:OSS:BucketName"];
            public static int Expire => int.Parse(_config["ALiYun:OSS:Policy:Expire"]);
            public static int MaxSize =>int.Parse( _config["ALiYun:OSS:MaxSize"]);
            public static string Callback => _config["ALiYun:OSS:Callback"];
            public static string DirPrefix => _config["ALiYun:OSS:Dir:Prefix"];
        }
    
        public static class MinIO
        {
            public static string EndPoint => _config["MinIO:EndPoint"];
            public static string BucketName => _config["MinIO:BucketName"];
            public static string AccessKey => _config["MinIO:AccessKey"];
            public static string SecretKey => _config["MinIO:SecretKey"];
        }
    }
}
