using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailTask : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        public Guid TemplateId { get; private set; }

        public Guid? SmtpAccountId { get; private set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength128)]
        public string MailTo { get; private set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength255)]
        public string Subject { get; private set; }

        public bool IsActive { get; private set; }

        public MailStatus Status { get; private set; }

        public ICollection<MailLog> Logs { get; protected set; }

        protected MailTask()
        {
        }

        public MailTask(
            Guid id,
            Guid? tenantId,
            Guid templateId,
            Guid? smtpAccountId,
            string mailTo,
            string subject,
            bool isActive,
            MailStatus status,
            ICollection<MailLog> logs
        ) : base(id)
        {
            TenantId = tenantId;
            TemplateId = templateId;
            SmtpAccountId = smtpAccountId;
            MailTo = Check.NotNullOrWhiteSpace(mailTo, nameof(mailTo));
            Subject = subject;
            IsActive = isActive;
            Status = status;
            Logs = logs;
        }

        public void Update(
            Guid templateId,
            Guid? smtpAccountId,
            string mailTo,
            string subject,
            bool isActive,
            MailStatus status
        )
        {
            TemplateId = templateId;
            SmtpAccountId = smtpAccountId;
            MailTo = Check.NotNullOrWhiteSpace(mailTo, nameof(mailTo));
            Subject = subject;
            IsActive = isActive;
            Status = status;
            Logs = new Collection<MailLog>();
        }

        public void ResetStatus()
        {
            Status = MailStatus.Pending;
        }

        public void SetAsProcessing()
        {
            if (Status == MailStatus.Pending)
            {
                Status = MailStatus.Processing;
            }
        }

        public void SetAsSucceed()
        {
            if (Status == MailStatus.Processing)
            {
                Status = MailStatus.Succeed;
            }
        }

        public void SetAsFailed()
        {
            if (Status == MailStatus.Processing)
            {
                Status = MailStatus.Failed;
            }
        }

        public void AddLog(Guid logId, [NotNull] string log, IDictionary<string, object> properties = null)
        {
            if (null == Logs)
                Logs = new Collection<MailLog>();

            Logs.Add(new MailLog(logId, Id, log, properties));
        }
    }
}
