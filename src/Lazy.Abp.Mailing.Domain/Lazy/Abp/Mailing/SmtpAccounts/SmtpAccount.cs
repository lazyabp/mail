using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Validation;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public class SmtpAccount : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; protected set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength64)]
        public string Host { get; private set; }

        public int Port { get; private set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength64)]
        public string Account { get; private set; }

        [NotNull]
        [MaxLength(MailingConsts.MaxLength128)]
        public string Password { get; private set; }

        public bool UseSsl { get; private set; }

        public int Power { get; private set; }

        [MaxLength(MailingConsts.MaxLength128)]
        public string SenderEmail { get; private set; }

        [CanBeNull]
        [MaxLength(MailingConsts.MaxLength128)]
        public string SenderName { get; private set; }

        public bool IsActive { get; private set; }

        protected SmtpAccount()
        {
        }

        public SmtpAccount(
            Guid id,
            Guid? tenantId,
            string host,
            int port,
            string account,
            string password,
            bool useSsl,
            int power,
            string senderEmail,
            string senderName,
            bool isActive
        ) : base(id)
        {
            TenantId = tenantId;
            Host = Check.NotNullOrWhiteSpace(host, nameof(host));
            Port = port;
            Account = Check.NotNullOrWhiteSpace(account, nameof(account));
            Password = Check.NotNullOrWhiteSpace(password, nameof(password));
            UseSsl = useSsl;
            Power = power;
            SenderEmail = senderEmail.IsNullOrWhiteSpace() ? account : senderEmail;
            SenderName = senderName;
            IsActive = isActive;
        }

        public void Update(
            string host,
            int port,
            string account,
            string password,
            bool useSsl,
            int power,
            string senderEmail,
            string senderName,
            bool isActive
        )
        {
            Host = Check.NotNullOrWhiteSpace(host, nameof(host));
            Port = port;
            Account = Check.NotNullOrWhiteSpace(account, nameof(account));
            Password = Check.NotNullOrWhiteSpace(password, nameof(password));
            UseSsl = useSsl;
            Power = power;
            SenderEmail = senderEmail.IsNullOrWhiteSpace() ? account : senderEmail;
            SenderName = senderName;
            IsActive = isActive;
        }
    }
}
