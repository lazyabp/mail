using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask
{
    public class CreateModalModel : MailingPageModel
    {
        [BindProperty]
        public CreateEditMailTaskViewModel ViewModel { get; set; }

        private readonly IMailTaskAppService _service;

        public CreateModalModel(IMailTaskAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditMailTaskViewModel, MailTaskCreateUpdateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}