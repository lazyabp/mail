using Lazy.Abp.Mailing.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing
{
    public abstract class MailingAppService : ApplicationService
    {
        protected MailingAppService()
        {
            LocalizationResource = typeof(MailingResource);
            ObjectMapperContext = typeof(MailingApplicationModule);
        }
    }
}
