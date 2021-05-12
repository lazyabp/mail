using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    [RemoteService(Name = MailingRemoteServiceConsts.RemoteServiceName)]
    [Area("Mailing")]
    [ControllerName("SmtpAccount")]
    [Route("api/mailing/smtp-accounts")]
    public class SmtpAccountController : MailingController, ISmtpAccountAppService
    {
        private readonly ISmtpAccountAppService _service;

        public SmtpAccountController(ISmtpAccountAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<SmtpAccountDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<SmtpAccountDto>> GetListAsync(SmtpAccountListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<SmtpAccountDto> CreateAsync(SmtpAccountCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<SmtpAccountDto> UpdateAsync(Guid id, SmtpAccountCreateUpdateDto input)
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
