using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.Templates.Dtos
{
    public class TemplateListRequestDto : PagedAndSortedResultRequestDto
    {
        public string GroupName { get; set; }

        public string Filter { get; set; }
    }
}
