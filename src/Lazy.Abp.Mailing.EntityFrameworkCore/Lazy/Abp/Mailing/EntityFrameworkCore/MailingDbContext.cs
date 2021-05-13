using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.Templates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    [ConnectionStringName(MailingDbProperties.ConnectionStringName)]
    public class MailingDbContext : AbpDbContext<MailingDbContext>, IMailingDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Template> Templates { get; set; }
        public DbSet<SmtpAccount> SmtpAccounts { get; set; }
        public DbSet<MailTask> MailTasks { get; set; }
        public DbSet<MailLog> MailLogs { get; set; }

        public MailingDbContext(DbContextOptions<MailingDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMailing();
        }
    }
}