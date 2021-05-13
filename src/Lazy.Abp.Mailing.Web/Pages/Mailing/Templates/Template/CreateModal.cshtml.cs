using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lazy.Abp.Mailing.Templates;
using Lazy.Abp.Mailing.Templates.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template.ViewModels;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template
{
    public class CreateModalModel : MailingPageModel
    {
        [BindProperty]
        public CreateEditTemplateViewModel ViewModel { get; set; }

        private readonly ITemplateAppService _service;

        public CreateModalModel(ITemplateAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditTemplateViewModel, TemplateCreateUpdateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}