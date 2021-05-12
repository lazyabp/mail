using AutoMapper;
using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Lazy.Abp.Mailing.Templates;
using Lazy.Abp.Mailing.Templates.Dtos;

namespace Lazy.Abp.Mailing
{
    public class MailingApplicationAutoMapperProfile : Profile
    {
        public MailingApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Template, TemplateDto>();
            CreateMap<TemplateCreateUpdateDto, Template>(MemberList.Source);
            CreateMap<SmtpAccount, SmtpAccountDto>();
            CreateMap<SmtpAccountCreateUpdateDto, SmtpAccount>(MemberList.Source);
            CreateMap<MailTask, MailTaskDto>();
            CreateMap<MailTaskCreateUpdateDto, MailTask>(MemberList.Source);
            CreateMap<MailLog, MailLogDto>();
        }
    }
}