using System;
using Lazy.Abp.Mailing.Templates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.Templates
{
    public interface ITemplateAppService :
        ICrudAppService< 
            TemplateDto, 
            Guid,
            TemplateListRequestDto,
            TemplateCreateUpdateDto,
            TemplateCreateUpdateDto>
    {

    }
}