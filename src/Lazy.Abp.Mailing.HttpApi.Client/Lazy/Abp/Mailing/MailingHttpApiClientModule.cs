using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(MailingApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MailingHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Mailing";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MailingApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
