using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.Mailing.SmtpAccounts.Dtos
{
    public class SmtpAccountListRequestDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }

        public string Filter { get; set; }
    }
}
