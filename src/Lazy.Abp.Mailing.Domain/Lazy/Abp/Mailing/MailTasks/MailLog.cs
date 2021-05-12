using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailLog : CreationAuditedEntity<Guid>, IHasExtraProperties
    {
        public Guid MailTaskId { get; private set; }

        [NotNull]
        public string Log { get; private set; }

        public ExtraPropertyDictionary ExtraProperties { get; set; }

        protected MailLog()
        {
        }

        internal MailLog(
            Guid id,
            Guid mailTaskId,
            string log,
            IDictionary<string, object> properties = null
        ) : base(id)
        {
            MailTaskId = mailTaskId;
            Log = log;

            if (null != properties)
                ExtraProperties = new ExtraPropertyDictionary(properties);
        }
    }
}
