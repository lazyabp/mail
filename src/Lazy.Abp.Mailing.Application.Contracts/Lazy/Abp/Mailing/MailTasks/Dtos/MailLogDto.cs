using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.MailTasks.Dtos
{
    [Serializable]
    public class MailLogDto : ExtensibleCreationAuditedEntityDto<Guid>
    {
        public Guid MailTaskId { get; set; }

        public string Log { get; set; }
    }
}