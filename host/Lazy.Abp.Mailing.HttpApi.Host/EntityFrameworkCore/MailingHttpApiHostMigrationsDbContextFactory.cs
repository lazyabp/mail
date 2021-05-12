using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    public class MailingHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<MailingHttpApiHostMigrationsDbContext>
    {
        public MailingHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MailingHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Mailing"));

            return new MailingHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
