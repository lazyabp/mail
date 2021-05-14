using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Mailing.MailTasks
{
    [Serializable]
    public class MailTaskEto
    {
        public Guid Id { get; set; }

        public Guid? TenantId { get; set; }

        public Guid TemplateId { get; set; }

        public Guid? SmtpAccountId { get; set; }

        [NotNull]
        public string MailTo { get; set; }

        public string Subject { get; set; }

        public bool IsActive { get; set; }

        public MailStatus Status { get; set; }

        public DateTime? PlanedSendingTime { get; set; }
    }
}
