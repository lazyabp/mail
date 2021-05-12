using System;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public interface ISmtpAccountAppService :
        ICrudAppService< 
            SmtpAccountDto, 
            Guid,
            SmtpAccountListRequestDto,
            SmtpAccountCreateUpdateDto,
            SmtpAccountCreateUpdateDto>
    {

    }
}