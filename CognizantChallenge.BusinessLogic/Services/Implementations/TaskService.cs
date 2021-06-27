using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<IEnumerable<Core.Database.Entities.Task>> GetAllTasksAsync()
        {
            var tasks = await taskRepository.GetAllAsync();
            return tasks;
        }

        public async Task<Core.Database.Entities.Task> GetTaskByIdAsync(int id)
        {
            var task = await taskRepository.GetByIdAsync(id);
            return task;
        }
    }
}
