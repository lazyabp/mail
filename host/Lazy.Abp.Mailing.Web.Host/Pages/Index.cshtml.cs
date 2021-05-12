using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Lazy.Abp.Mailing.Pages
{
    public class IndexModel : MailingPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}