using System.Threading.Tasks;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CognizantChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await taskService.GetAllTasksAsync();
            return new JsonResult(tasks);
        }
    }
}