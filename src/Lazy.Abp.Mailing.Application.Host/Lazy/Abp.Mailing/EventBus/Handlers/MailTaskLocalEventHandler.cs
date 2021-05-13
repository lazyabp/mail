using Lazy.Abp.Mailing.BackgroundJobs;
using Lazy.Abp.Mailing.MailTasks;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace Lazy.Abp.Mailing.EventBus.Handlers
{
    public class MailTaskLocalEventHandler :
        ILocalEventHandler<EntityCreatedEto<MailTaskEto>>,
        ILocalEventHandler<EntityUpdatedEto<MailTaskEto>>,
        ITransientDependency
    {
        protected IBackgroundJobManager BackgroundJobManager { get; }

        public MailTaskLocalEventHandler(IBackgroundJobManager backgroundJobManager)
        {
            BackgroundJobManager = backgroundJobManager;
        }

        public async Task HandleEventAsync(EntityCreatedEto<MailTaskEto> eventData)
        {
            if (eventData.Entity.Status == MailStatus.Pending)
            {
                await BackgroundJobManager.EnqueueAsync(new MailingSendingJobArgs
                {
                    TenantId = eventData.Entity.TenantId,
                    MailTaskId = eventData.Entity.Id
                });
            }
        }

        public async Task HandleEventAsync(EntityUpdatedEto<MailTaskEto> eventData)
        {
            if (eventData.Entity.Status == MailStatus.Pending)
            {
                await BackgroundJobManager.EnqueueAsync(new MailingSendingJobArgs
                {
                    TenantId = eventData.Entity.TenantId,
                    MailTaskId = eventData.Entity.Id
                });
            }
        }
    }
}
