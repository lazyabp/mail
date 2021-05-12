using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.MailTasks
{
    [RemoteService(Name = MailingRemoteServiceConsts.RemoteServiceName)]
    [Area("Mailing")]
    [ControllerName("MailTask")]
    [Route("api/mailing/mail-task")]
    public class MailTaskController : MailingController, IMailTaskAppService
    {
        private readonly IMailTaskAppService _service;

        public MailTaskController(IMailTaskAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<MailTaskDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<MailTaskDto>> GetListAsync(MailTaskListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<MailTaskDto> CreateAsync(MailTaskCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<MailTaskDto> UpdateAsync(Guid id, MailTaskCreateUpdateDto input)
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
