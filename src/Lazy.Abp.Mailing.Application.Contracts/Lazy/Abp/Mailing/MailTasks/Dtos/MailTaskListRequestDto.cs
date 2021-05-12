using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailTaskListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }

        public MailStatus? Status { get; set; }

        public string Filter { get; set; }

        //public bool IncludeDetails { get; set; }
    }
}
