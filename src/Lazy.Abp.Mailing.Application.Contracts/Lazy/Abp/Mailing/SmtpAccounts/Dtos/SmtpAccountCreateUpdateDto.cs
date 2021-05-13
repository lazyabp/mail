using System;

namespace Lazy.Abp.Mailing.SmtpAccounts.Dtos
{
    [Serializable]
    public class SmtpAccountCreateUpdateDto
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public bool UseSsl { get; set; }

        public int Power { get; set; }

        public string SenderEmail { get; set; }

        public string SenderName { get; set; }

        public bool IsActive { get; set; }
    }
}