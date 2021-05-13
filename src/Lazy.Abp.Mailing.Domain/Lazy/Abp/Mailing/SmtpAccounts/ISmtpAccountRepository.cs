using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public interface ISmtpAccountRepository : IRepository<SmtpAccount, Guid>
    {
        Task<SmtpAccount> GetByIdAsync(Guid id, bool? isActive = null);

        Task<List<SmtpAccount>> GetAllAsync(bool? isActive = null);
    }
}