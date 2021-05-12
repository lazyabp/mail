using System;
using Lazy.Abp.Mailing.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Mailing.Templates
{
    public class TemplateRepository : EfCoreRepository<IMailingDbContext, Template, Guid>, ITemplateRepository
    {
        public TemplateRepository(IDbContextProvider<IMailingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}