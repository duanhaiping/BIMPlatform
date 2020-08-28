﻿using log4net;
using log4net.Config;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace Platform.ToolKits.Extensions
{
    public static class Log4NetExtensions
    {
        public static IHostBuilder UseLog4Net(this IHostBuilder hostBuilder)
        {
            var log4netRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));

            return hostBuilder;
        }
    }
}
