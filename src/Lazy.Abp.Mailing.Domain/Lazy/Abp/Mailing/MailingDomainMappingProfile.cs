using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Lazy.Abp.Mailing.MailTasks;

namespace Lazy.Abp.Mailing
{
    public class MailingDomainMappingProfile : Profile
    {
        public MailingDomainMappingProfile()
        {
            CreateMap<MailTask, MailTaskEto>();
        }
    }
}
