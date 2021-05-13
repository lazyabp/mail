using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.Localization;
using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.Templates;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Net.Mail;

namespace Lazy.Abp.Mailing.BackgroundJobs
{
    public class MailingSendingJob : AsyncBackgroundJob<MailingSendingJobArgs>, IUnitOfWorkEnabled, ITransientDependency
    {
        private readonly MailTaskManager _mailTaskManager;
        private readonly TemplateManager _templateManager;
        private readonly SmtpAccountManager _smtpAccountManager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IStringLocalizer<MailingResource> _stringLocalizer;

        public MailingSendingJob(
            MailTaskManager mailTaskManager,
            TemplateManager templateManager,
            SmtpAccountManager smtpAccountManager,
            IGuidGenerator guidGenerator,
            IStringLocalizer<MailingResource> stringLocalizer
        )
        {
            _mailTaskManager = mailTaskManager;
            _templateManager = templateManager;
            _smtpAccountManager = smtpAccountManager;
            _guidGenerator = guidGenerator;
            _stringLocalizer = stringLocalizer;
        }

        [UnitOfWork]
        public override async Task ExecuteAsync(MailingSendingJobArgs args)
        {
            // 待发送的邮件
            var mailTask = await _mailTaskManager.GetByIdAsync(args.MailTaskId, false, args.TenantId);
            if (mailTask.Status != MailStatus.Pending)
            {
                mailTask.AddLog(_guidGenerator.Create(), L("InvalidStatus", nameof(mailTask.Status)));
                mailTask.SetAsFailed();
                return;
            }

            // 用户配置的SMTP账号
            IList<SmtpAccount> smtpAccounts = new List<SmtpAccount>();
            if (mailTask.SmtpAccountId.HasValue)
            {
                var smtpAccount = await _smtpAccountManager.GetByIdAsync(mailTask.SmtpAccountId.Value, true, args.TenantId);
                if (null == smtpAccount)
                {
                    mailTask.AddLog(_guidGenerator.Create(), L("NoFoundAnyMailSendingAccounts"));
                    mailTask.SetAsFailed();
                    return;
                }

                smtpAccounts.Add(smtpAccount);
            }
            else
            {
                smtpAccounts = await _smtpAccountManager.GetAllAsync(args.TenantId);
                if (smtpAccounts?.Count == 0)
                {
                    mailTask.AddLog(_guidGenerator.Create(), L("NoConfigMailSendingAccounts"));
                    mailTask.SetAsFailed();
                    return;
                }
            }

            // 邮件内容
            var template = await _templateManager.GetByIdAsync(mailTask.TemplateId, args.TenantId);

            // 修改邮件状态
            mailTask.SetAsProcessing();

            // 邮件主题
            var subject = mailTask.Subject.IsNullOrWhiteSpace() 
                ? (template.Subject.IsNullOrWhiteSpace() ? template.Name : template.Subject) 
                : mailTask.Subject;

            // 找一个可用的SMTP配置发送邮件
            foreach (var smtpAccount in smtpAccounts)
            {
                var from = smtpAccount.SenderEmail.IsNullOrWhiteSpace() ? smtpAccount.Account : smtpAccount.SenderEmail;

                var mail = new MailMessage(from, mailTask.MailTo, subject, template.TemplateContent)
                {
                    IsBodyHtml = true
                };

                var properties = new Dictionary<string, object>
                {
                    { "Sender", from }
                };

                try
                {
                    // 发送邮件
                    using (var client = await BuildClientAsync(smtpAccount))
                    {
                        var message = MimeMessage.CreateFromMailMessage(mail);
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);

                        mailTask.AddLog(_guidGenerator.Create(), L("MailSentSuccessfully"), properties);
                        mailTask.SetAsSucceed();

                        return;
                    }
                }
                catch(Exception ex)
                {
                    mailTask.AddLog(_guidGenerator.Create(), ex.Message, properties);
                }
            }

            // 发送失败
            mailTask.SetAsFailed();
        }

        private async Task<SmtpClient> BuildClientAsync(SmtpAccount config)
        {
            var client = new SmtpClient();

            try
            {
                await client.ConnectAsync(config.Host, config.Port, config.UseSsl);
                await client.AuthenticateAsync(config.Account, config.Password);

                return client;
            }
            catch
            {
                client.Dispose();
                throw;
            }
        }

        protected string L(string name, params object[] args)
        {
            return _stringLocalizer[name, args]?.Value;
        }
    }
}
