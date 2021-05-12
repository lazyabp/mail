using System;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.MailTasks
{
    public interface IMailTaskAppService :
        ICrudAppService< 
            MailTaskDto, 
            Guid,
            MailTaskListRequestDto,
            MailTaskCreateUpdateDto,
            MailTaskCreateUpdateDto>
    {

    }
}