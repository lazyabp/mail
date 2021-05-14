using Lazy.Abp.Mailing.BackgroundJobs;
using Lazy.Abp.Mailing.MailTasks;
using System;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Timing;

namespace Lazy.Abp.Mailing.EventBus.Handlers
{
    public class MailTaskDistributedEventHandler :
        IDistributedEventHandler<EntityCreatedEto<MailTaskEto>>,
        IDistributedEventHandler<EntityUpdatedEto<MailTaskEto>>,
        ITransientDependency
    {
        protected IBackgroundJobManager BackgroundJobManager { get; }
        protected IClock Clock { get; }

        public MailTaskDistributedEventHandler(
            IBackgroundJobManager backgroundJobManager,
            IClock clock
        )
        {
            BackgroundJobManager = backgroundJobManager;
            Clock = clock;
        }

        public async Task HandleEventAsync(EntityCreatedEto<MailTaskEto> eventData)
        {
            if (eventData.Entity.Status == MailStatus.Pending)
            {
                await QueueAsync(eventData.Entity);
            }
        }

        public async Task HandleEventAsync(EntityUpdatedEto<MailTaskEto> eventData)
        {
            if (eventData.Entity.Status == MailStatus.Pending)
            {
                await QueueAsync(eventData.Entity);
            }
        }

        protected async Task QueueAsync(MailTaskEto mailTask)
        {
            TimeSpan? delay = null;
            if (mailTask.PlanedSendingTime.HasValue && mailTask.PlanedSendingTime.Value > Clock.Now)
            {
                delay = mailTask.PlanedSendingTime.Value - Clock.Now;
            }

            await BackgroundJobManager.EnqueueAsync(new MailingSendingJobArgs
            {
                TenantId = mailTask.TenantId,
                MailTaskId = mailTask.Id
            }, delay: delay);
        }
    }
}
