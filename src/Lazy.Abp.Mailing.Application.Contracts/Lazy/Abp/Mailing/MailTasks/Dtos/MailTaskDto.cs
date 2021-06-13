using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.MailTasks.Dtos
{
    [Serializable]
    public class MailTaskDto : FullAuditedEntityDto<Guid>
    {
        public Guid TemplateId { get; set; }

        public Guid? SmtpAccountId { get; set; }

        public string MailTo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsActive { get; set; }

        public MailStatus Status { get; set; }

        public DateTime? PlanedSendingTime { get; set; }

        public List<MailLogDto> Logs { get; set; }
    }
}