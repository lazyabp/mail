using AutoMapper;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Lazy.Abp.Mailing.Templates.Dtos;
using Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask.ViewModels;
using Lazy.Abp.Mailing.Web.Pages.Mailing.SmtpAccounts.SmtpAccount.ViewModels;
using Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template.ViewModels;

namespace Lazy.Abp.Mailing.Web
{
    public class MailingWebAutoMapperProfile : Profile
    {
        public MailingWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<MailTaskDto, CreateEditMailTaskViewModel>();
            CreateMap<CreateEditMailTaskViewModel, MailTaskCreateUpdateDto>();
            CreateMap<SmtpAccountDto, CreateEditSmtpAccountViewModel>();
            CreateMap<CreateEditSmtpAccountViewModel, SmtpAccountCreateUpdateDto>();
            CreateMap<TemplateDto, CreateEditTemplateViewModel>();
            CreateMap<CreateEditTemplateViewModel, TemplateCreateUpdateDto>();
        }
    }
}