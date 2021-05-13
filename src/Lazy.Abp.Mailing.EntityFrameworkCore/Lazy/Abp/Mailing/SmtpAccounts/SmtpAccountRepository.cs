using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public class SmtpAccountRepository : EfCoreRepository<IMailingDbContext, SmtpAccount, Guid>, ISmtpAccountRepository
    {
        public SmtpAccountRepository(IDbContextProvider<IMailingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<SmtpAccount> GetByIdAsync(Guid id, bool? isActive = null)
        {
            return await (await GetQueryableAsync())
                .WhereIf(isActive.HasValue, q => q.IsActive == isActive)
                .Where(q => q.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SmtpAccount>> GetAllAsync(bool? isActive = null)
        {
            return await (await GetQueryableAsync())
                .WhereIf(isActive.HasValue, q => q.IsActive == isActive)
                .OrderBy(q => q.Power)
                .ToListAsync();
        }
    }
}