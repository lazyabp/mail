using Lazy.Abp.Mailing.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(MailingEntityFrameworkCoreTestModule)
        )]
    public class MailingDomainTestModule : AbpModule
    {
        
    }
}
