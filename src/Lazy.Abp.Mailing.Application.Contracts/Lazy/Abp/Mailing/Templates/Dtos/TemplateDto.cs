using System;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.Templates.Dtos
{
    [Serializable]
    public class TemplateDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }

        public bool IsActive { get; set; }

        public string TemplateContent { get; set; }
    }
}