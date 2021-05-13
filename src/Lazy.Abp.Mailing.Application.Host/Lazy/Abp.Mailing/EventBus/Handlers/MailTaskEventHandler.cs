using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lazy.Abp.Mailing.BackgroundJobs;
using Lazy.Abp.Mailing.MailTasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Lazy.Abp.Mailing.EventBus.Handlers
{
    public class MailTaskEventHandler : IDistributedEventHandler<MailTaskEto>, ITransientDependency
    {
        protected IBackgroundJobManager BackgroundJobManager { get; }

        public MailTaskEventHandler(IBackgroundJobManager backgroundJobManager)
        {
            BackgroundJobManager = backgroundJobManager;
        }

        public async Task HandleEventAsync(MailTaskEto eventData)
        {
            await BackgroundJobManager.EnqueueAsync(new MailingSendingJobArgs
            {
                TenantId = eventData.TenantId,
                MailTaskId = eventData.Id
            });
        }
    }
}
