using System;
using System.Linq;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.Permissions;
using Lazy.Abp.Mailing.SmtpAccounts.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.SmtpAccounts
{
    public class SmtpAccountAppService : CrudAppService<SmtpAccount, SmtpAccountDto, Guid, SmtpAccountListRequestDto, SmtpAccountCreateUpdateDto, SmtpAccountCreateUpdateDto>,
        ISmtpAccountAppService
    {
        protected override string GetPolicyName { get; set; } = MailingPermissions.SmtpAccount.Default;
        protected override string GetListPolicyName { get; set; } = MailingPermissions.SmtpAccount.Default;
        protected override string CreatePolicyName { get; set; } = MailingPermissions.SmtpAccount.Create;
        protected override string UpdatePolicyName { get; set; } = MailingPermissions.SmtpAccount.Update;
        protected override string DeletePolicyName { get; set; } = MailingPermissions.SmtpAccount.Delete;

        private readonly ISmtpAccountRepository _repository;
        
        public SmtpAccountAppService(ISmtpAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<SmtpAccount>> CreateFilteredQueryAsync(SmtpAccountListRequestDto input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .WhereIf(input.IsActive.HasValue, q => q.IsActive == input.IsActive)
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    q => false
                    || q.Host.Contains(input.Filter)
                    || q.Account.Contains(input.Filter)
                    || q.SenderEmail.Contains(input.Filter)
                    || q.SenderName.Contains(input.Filter)
                );
        }
    }
}
