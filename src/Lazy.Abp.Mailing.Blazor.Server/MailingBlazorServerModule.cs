using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(MailingBlazorModule)
        )]
    public class MailingBlazorServerModule : AbpModule
    {
        
    }
}