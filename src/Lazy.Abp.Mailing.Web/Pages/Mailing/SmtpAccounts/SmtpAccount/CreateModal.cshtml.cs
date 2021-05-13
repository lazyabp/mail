using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount
{
    public class CreateModalModel : MailingPageModel
    {
        [BindProperty]
        public CreateEditSmtpAccountViewModel ViewModel { get; set; }

        private readonly ISmtpAccountAppService _service;

        public CreateModalModel(ISmtpAccountAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditSmtpAccountViewModel, SmtpAccountCreateUpdateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}