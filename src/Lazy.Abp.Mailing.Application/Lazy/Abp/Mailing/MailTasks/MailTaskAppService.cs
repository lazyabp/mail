using System;
using System.Linq;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.MailTasks.Dtos;
using Lazy.Abp.Mailing.Permissions;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailTaskAppService : CrudAppService<MailTask, MailTaskDto, Guid, MailTaskListRequestDto, MailTaskCreateUpdateDto, MailTaskCreateUpdateDto>,
        IMailTaskAppService
    {
        protected override string GetPolicyName { get; set; } = MailingPermissions.MailTask.Default;
        protected override string GetListPolicyName { get; set; } = MailingPermissions.MailTask.Default;
        protected override string CreatePolicyName { get; set; } = MailingPermissions.MailTask.Create;
        protected override string UpdatePolicyName { get; set; } = MailingPermissions.MailTask.Update;
        protected override string DeletePolicyName { get; set; } = MailingPermissions.MailTask.Delete;

        private readonly IMailTaskRepository _repository;
        
        public MailTaskAppService(IMailTaskRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<MailTask>> CreateFilteredQueryAsync(MailTaskListRequestDto input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .WhereIf(input.IsActive.HasValue, q => q.IsActive == input.IsActive)
                .WhereIf(input.Status.HasValue, q => q.Status == input.Status)
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    q => false
                    || q.MailTo.Contains(input.Filter)
                );
        }
    }
}
