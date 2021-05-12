using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    [ConnectionStringName(MailingDbProperties.ConnectionStringName)]
    public interface IMailingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}