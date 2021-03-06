using System;

namespace Lazy.Abp.Mailing.Templates.Dtos
{
    [Serializable]
    public class TemplateCreateUpdateDto
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }

        public string TemplateContent { get; set; }
    }
}