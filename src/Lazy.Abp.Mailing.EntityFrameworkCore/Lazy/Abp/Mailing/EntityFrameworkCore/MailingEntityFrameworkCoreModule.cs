using Lazy.Abp.Mailing.MailTasks;
using Lazy.Abp.Mailing.SmtpAccounts;
using Lazy.Abp.Mailing.Templates;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Mailing.EntityFrameworkCore
{
    [DependsOn(
        typeof(MailingDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MailingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MailingDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Template, TemplateRepository>();
                options.AddRepository<SmtpAccount, SmtpAccountRepository>();
                options.AddRepository<MailTask, MailTaskRepository>();
            });
        }
    }
}