using Lazy.Abp.Mailing.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Mailing
{
    public abstract class MailingController : AbpController
    {
        protected MailingController()
        {
            LocalizationResource = typeof(MailingResource);
        }
    }
}
