using System.Threading.Tasks;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount
{
    public class IndexModel : MailingPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
