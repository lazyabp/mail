using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

namespace Lazy.Abp.Mailing.MailTasks
{
    public class MailTaskManager : DomainService
    {
        private readonly IMailTaskRepository _repository;
        private readonly IGuidGenerator _guidGenerator;

        public MailTaskManager(
            IMailTaskRepository repository,
            IGuidGenerator guidGenerator
        )
        {
            _repository = repository;
            _guidGenerator = guidGenerator;
        }

        public async Task<MailTask> AddLog(Guid mailTaskId, string log, IDictionary<string, object> properties = null)
        {
            var task = await _repository.GetAsync(mailTaskId);
            task.AddLog(_guidGenerator.Create(), log, properties);

            await _repository.UpdateAsync(task);

            return task;
        }
    }
}
