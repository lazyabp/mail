using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    public class MailingHttpApiHostMigrationsDbContext : AbpDbContext<MailingHttpApiHostMigrationsDbContext>
    {
        public MailingHttpApiHostMigrationsDbContext(DbContextOptions<MailingHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureMailing();
        }
    }
}
