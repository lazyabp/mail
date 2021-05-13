using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.Mailing.Templates
{
    public class TemplateManager : DomainService
    {
        private readonly ITemplateRepository _repository;

        public TemplateManager(
            ITemplateRepository repository
        )
        {
            _repository = repository;
        }

        public async Task<Template> GetByIdAsync(Guid id, Guid? tenantId = null)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAsync(id);
            }
        }
    }
}
