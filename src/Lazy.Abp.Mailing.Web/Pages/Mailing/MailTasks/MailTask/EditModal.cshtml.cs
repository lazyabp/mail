using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask
{
    public class EditModalModel : MailingPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditMailTaskViewModel ViewModel { get; set; }

        private readonly IMailTaskAppService _service;

        public EditModalModel(IMailTaskAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<MailTaskDto, CreateEditMailTaskViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditMailTaskViewModel, MailTaskCreateUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}