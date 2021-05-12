using Lazy.Abp.Mailing.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.Mailing.Pages
{
    public abstract class MailingPageModel : AbpPageModel
    {
        protected MailingPageModel()
        {
            LocalizationResourceType = typeof(MailingResource);
        }
    }
}