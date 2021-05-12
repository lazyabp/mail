using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    public class MailingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MailingModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}