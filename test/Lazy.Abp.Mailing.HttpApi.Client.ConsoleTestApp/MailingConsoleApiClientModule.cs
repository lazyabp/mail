using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(MailingHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MailingConsoleApiClientModule : AbpModule
    {
        
    }
}
