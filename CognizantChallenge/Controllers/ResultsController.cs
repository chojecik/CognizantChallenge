using System.Threading.Tasks;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CognizantChallenge.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService resultService;

        public ResultsController(IResultService resultService)
        {
            this.resultService = resultService;
        }

        [HttpGet("results")]
        public async Task<IActionResult> GetResults()
        {
            var results = await resultService.GetTopThreeResultsAsync();
            return new JsonResult(results);
        }
    }
}