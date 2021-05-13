using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public class SmtpAccountManager : DomainService
    {
        private readonly ISmtpAccountRepository _repository;

        public SmtpAccountManager(
            ISmtpAccountRepository repository
        )
        {
            _repository = repository;
        }

        public async Task<SmtpAccount> GetByIdAsync(Guid id, bool? isActive = null, Guid? tenantId = null)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetByIdAsync(id, isActive);
            }
        }

        public async Task<IList<SmtpAccount>> GetAllAsync(Guid? tenantId = null)
        {
            using (CurrentTenant.Change(tenantId))
            {
                return await _repository.GetAllAsync(true);
            }
        }
    }
}
