using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount
{
    public class EditModalModel : MailingPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditSmtpAccountViewModel ViewModel { get; set; }

        private readonly ISmtpAccountAppService _service;

        public EditModalModel(ISmtpAccountAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<SmtpAccountDto, CreateEditSmtpAccountViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditSmtpAccountViewModel, SmtpAccountCreateUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}