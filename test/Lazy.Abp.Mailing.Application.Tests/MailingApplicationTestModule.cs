using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    [DependsOn(
        typeof(MailingApplicationModule),
        typeof(MailingDomainTestModule)
        )]
    public class MailingApplicationTestModule : AbpModule
    {

    }
}
