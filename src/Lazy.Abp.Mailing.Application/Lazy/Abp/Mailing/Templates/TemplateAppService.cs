using System;
using System.Linq;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.Permissions;
using Lazy.Abp.Mailing.Templates.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Mailing.Templates
{
    public class TemplateAppService : CrudAppService<Template, TemplateDto, Guid, TemplateListRequestDto, TemplateCreateUpdateDto, TemplateCreateUpdateDto>,
        ITemplateAppService
    {
        protected override string GetPolicyName { get; set; } = MailingPermissions.Template.Default;
        protected override string GetListPolicyName { get; set; } = MailingPermissions.Template.Default;
        protected override string CreatePolicyName { get; set; } = MailingPermissions.Template.Create;
        protected override string UpdatePolicyName { get; set; } = MailingPermissions.Template.Update;
        protected override string DeletePolicyName { get; set; } = MailingPermissions.Template.Delete;

        private readonly ITemplateRepository _repository;
        
        public TemplateAppService(ITemplateRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<Template>> CreateFilteredQueryAsync(TemplateListRequestDto input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .WhereIf(!input.GroupName.IsNullOrEmpty(), q => q.GroupName == input.GroupName)
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    q => false
                    || q.Name.Contains(input.Filter)
                    || q.Description.Contains(input.Filter)
                );
        }
    }
}
