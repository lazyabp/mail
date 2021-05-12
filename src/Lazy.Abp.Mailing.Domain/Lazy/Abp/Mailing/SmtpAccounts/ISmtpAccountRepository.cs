using System;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public interface ISmtpAccountRepository : IRepository<SmtpAccount, Guid>
    {
    }
}