using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Mailing.MongoDB
{
    [ConnectionStringName(MailingDbProperties.ConnectionStringName)]
    public class MailingMongoDbContext : AbpMongoDbContext, IMailingMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureMailing();
        }
    }
}