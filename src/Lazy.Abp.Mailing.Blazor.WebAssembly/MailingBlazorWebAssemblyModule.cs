using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing.Blazor.WebAssembly
{
    [DependsOn(
        typeof(MailingBlazorModule),
        typeof(MailingHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class MailingBlazorWebAssemblyModule : AbpModule
    {
        
    }
}