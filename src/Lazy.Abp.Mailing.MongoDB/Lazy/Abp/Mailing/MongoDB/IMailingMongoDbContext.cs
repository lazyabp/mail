using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Mailing.MongoDB
{
    [ConnectionStringName(MailingDbProperties.ConnectionStringName)]
    public interface IMailingMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
