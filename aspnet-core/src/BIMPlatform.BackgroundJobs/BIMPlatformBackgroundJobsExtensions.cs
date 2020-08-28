using BIMPlatform.BackgroundJobs.Jobs.Hangfire;
using Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace BIMPlatform.BackgroundJobs
{
    public static class BIMPlatformBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Second());
        }
    }
}
