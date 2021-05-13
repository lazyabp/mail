using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Mailing.BackgroundJobs
{
    [Serializable]
    public class MailingSendingJobArgs
    {
        public Guid? TenantId { get; set; }

        public Guid MailTaskId { get; set; }
    }
}
