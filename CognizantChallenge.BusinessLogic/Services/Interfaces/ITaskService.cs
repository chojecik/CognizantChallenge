using CognizantChallenge.Core.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods for operations on Task type
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Gets all tasks from database
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Core.Database.Entities.Task>> GetAllTasksAsync();

        /// <summary>
        /// Returns Task object by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Core.Database.Entities.Task> GetTaskByIdAsync(int id);
    }
}
