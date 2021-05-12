using Localization.Resources.AbpUi;
using Lazy.Abp.Mailing.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(MailingApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class MailingHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(MailingHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MailingResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
