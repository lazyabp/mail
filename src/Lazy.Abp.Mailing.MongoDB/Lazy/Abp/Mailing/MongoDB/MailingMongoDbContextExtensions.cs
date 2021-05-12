using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Mailing.MongoDB
{
    public static class MailingMongoDbContextExtensions
    {
        public static void ConfigureMailing(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MailingMongoModelBuilderConfigurationOptions(
                MailingDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}