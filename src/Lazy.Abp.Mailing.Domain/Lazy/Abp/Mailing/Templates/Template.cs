using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace Lazy.Abp.Mailing.Templates
{
    public class Template : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength255)]
        public string Name { get; private set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength255)]
        public string Subject { get; private set; }

        public string Description { get; private set; }

        [CanBeNull]
        [MaxLength(MailingConsts.MaxLength32)]
        public string GroupName { get; private set; }

        public string TemplateContent { get; private set; }

        protected Template()
        {
        }

        public Template(
            Guid id,
            Guid? tenantId,
            string name,
            string subject,
            string description,
            string groupName,
            string templateContent
        ) : base(id)
        {
            TenantId = tenantId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Subject = Check.NotNullOrWhiteSpace(subject, nameof(subject));
            Description = description;
            GroupName = groupName;
            TemplateContent = templateContent;
        }

        public void Update(
            string name,
            string subject,
            string description,
            string groupName,
            string templateContent
        )
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Subject = Check.NotNullOrWhiteSpace(subject, nameof(subject));
            Description = description;
            GroupName = groupName;
            TemplateContent = templateContent;
        }
    }
}
