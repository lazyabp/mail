using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.Templates.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.Templates
{
    [RemoteService(Name = MailingRemoteServiceConsts.RemoteServiceName)]
    [Area("Mailing")]
    [ControllerName("Template")]
    [Route("api/mailing/templates")]
    public class TemplateController : MailingController, ITemplateAppService
    {
        private readonly ITemplateAppService _service;

        public TemplateController(ITemplateAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<TemplateDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<TemplateDto>> GetListAsync(TemplateListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<TemplateDto> CreateAsync(TemplateCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<TemplateDto> UpdateAsync(Guid id, TemplateCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
