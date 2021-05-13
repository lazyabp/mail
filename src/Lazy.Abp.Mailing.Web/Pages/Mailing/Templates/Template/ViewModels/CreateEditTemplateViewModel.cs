using System;

namespace Lazy.Abp.Mailing.Web.Pages.Mailing.Templates.Template.ViewModels
{
    public class CreateEditTemplateViewModel
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }

        public string TemplateContent { get; set; }
    }
}