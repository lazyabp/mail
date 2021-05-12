using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(MailingDomainModule),
        typeof(MailingApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MailingApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MailingApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MailingApplicationModule>(validate: true);
            });
        }
    }
}
