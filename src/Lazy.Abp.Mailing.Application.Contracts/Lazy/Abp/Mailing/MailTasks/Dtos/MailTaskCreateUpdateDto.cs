using System;

namespace Lazy.Abp.Mailing.MailTasks.Dtos
{
    [Serializable]
    public class MailTaskCreateUpdateDto
    {
        public Guid TemplateId { get; set; }

        public Guid? SmtpAccountId { get; set; }

        public string MailTo { get; set; }

        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public MailStatus Status { get; set; }
    }
}