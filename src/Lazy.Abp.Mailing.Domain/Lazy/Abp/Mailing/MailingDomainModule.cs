using Lazy.Abp.Mailing.MailTasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpAutoMapperModule),
        typeof(MailingDomainSharedModule)
    )]
    public class MailingDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MailingDomainModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MailingDomainMappingProfile>(validate: true);
            });

            Configure<AbpDistributedEntityEventOptions>(options =>
            {
                options.AutoEventSelectors.Add<MailTask>();
                options.EtoMappings.Add<MailTask, MailTaskEto>(typeof(MailingDomainModule));
            });
        }
    }
}
