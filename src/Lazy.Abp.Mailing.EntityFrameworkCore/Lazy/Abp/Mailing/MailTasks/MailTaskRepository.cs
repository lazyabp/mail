using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailTaskRepository : EfCoreRepository<IMailingDbContext, MailTask, Guid>, IMailTaskRepository
    {
        public MailTaskRepository(IDbContextProvider<IMailingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<MailTask>> WithDetailsAsync()
        {
            return (await base.WithDetailsAsync())
                .Include(q => q.Logs);
        }
    }
}