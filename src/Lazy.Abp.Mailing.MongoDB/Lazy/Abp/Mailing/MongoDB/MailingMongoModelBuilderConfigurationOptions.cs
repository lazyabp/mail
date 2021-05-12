using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Mailing.MongoDB
{
    public class MailingMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MailingMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}