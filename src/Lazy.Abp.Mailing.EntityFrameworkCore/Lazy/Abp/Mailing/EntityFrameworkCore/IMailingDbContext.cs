using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.Templates;
using Microsoft.EntityFrameworkCore;
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
        DbSet<Template> Templates { get; set; }
        DbSet<SmtpAccount> SmtpAccounts { get; set; }
        DbSet<MailTask> MailTasks { get; set; }
        DbSet<MailLog> MailLogs { get; set; }
    }
}