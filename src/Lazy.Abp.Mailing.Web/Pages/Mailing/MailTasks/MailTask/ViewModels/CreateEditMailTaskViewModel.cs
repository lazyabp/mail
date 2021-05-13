using System;
using Lazy.Abp.Mailing.MailTasks;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.MailTasks.MailTask.ViewModels
{
    public class CreateEditMailTaskViewModel
    {
        public Guid TemplateId { get; set; }

        public Guid? SmtpAccountId { get; set; }

        public string MailTo { get; set; }

        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public MailStatus Status { get; set; }
    }
}