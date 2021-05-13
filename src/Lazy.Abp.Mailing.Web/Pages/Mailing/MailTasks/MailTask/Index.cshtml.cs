using System.Threading.Tasks;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask
{
    public class IndexModel : MailingPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
