using Lazy.Abp.Mailing.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.Mailing.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MailingPageModel : AbpPageModel
    {
        protected MailingPageModel()
        {
            LocalizationResourceType = typeof(MailingResource);
            ObjectMapperContext = typeof(MailingWebModule);
        }
    }
}