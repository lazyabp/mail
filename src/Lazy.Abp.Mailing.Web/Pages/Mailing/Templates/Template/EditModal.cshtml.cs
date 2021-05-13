using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.Templates;
using Lazy.Abp.Mailing.Templates.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template
{
    public class EditModalModel : MailingPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditTemplateViewModel ViewModel { get; set; }

        private readonly ITemplateAppService _service;

        public EditModalModel(ITemplateAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<TemplateDto, CreateEditTemplateViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditTemplateViewModel, TemplateCreateUpdateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}