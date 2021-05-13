using Lazy.Abp.Mailing.BackgroundJobs;
using System;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.EventBus.Abstractions;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(AbpBackgroundJobsAbstractionsModule),
        typeof(AbpEventBusAbstractionsModule),
        typeof(MailingApplicationModule)
        )]
    public class MailingApplicationHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options =>
            {
                options.AddJob<MailingSendingJob>();
            });
        }
    }
}
