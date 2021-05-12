using System;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.Mailing.Templates
{
    public interface ITemplateRepository : IRepository<Template, Guid>
    {
    }
}