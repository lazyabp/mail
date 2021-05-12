using System;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Mailing.MailTasks
{
    public interface IMailTaskRepository : IRepository<MailTask, Guid>
    {
    }
}