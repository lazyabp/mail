using Microsoft.Extensions.DependencyInjection;
using Lazy.Abp.Mailing.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Lazy.Abp.Mailing.Blazor
{
    [DependsOn(
        typeof(MailingApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MailingBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<MailingBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MailingBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new MailingMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(MailingBlazorModule).Assembly);
            });
        }
    }
}