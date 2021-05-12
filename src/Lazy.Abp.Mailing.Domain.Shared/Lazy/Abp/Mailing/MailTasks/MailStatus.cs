using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Mailing.MailTasks
{
    public enum MailStatus
    {
        Pending,
        Processing,
        Succeed,
        Failed
    }
}
