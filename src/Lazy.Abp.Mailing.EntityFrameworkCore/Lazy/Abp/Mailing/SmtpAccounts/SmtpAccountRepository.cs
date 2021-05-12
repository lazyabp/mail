using System;
using Lazy.Abp.Mailing.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public class SmtpAccountRepository : EfCoreRepository<IMailingDbContext, SmtpAccount, Guid>, ISmtpAccountRepository
    {
        public SmtpAccountRepository(IDbContextProvider<IMailingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}