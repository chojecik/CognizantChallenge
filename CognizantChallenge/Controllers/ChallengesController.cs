using System.Threading.Tasks;
using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CognizantChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallengeInterpreter challengeInterpreter;
        private readonly IConfiguration configuration;

        public ChallengesController(
            IChallengeInterpreter challengeInterpreter,
            IConfiguration configuration)
        {
            this.challengeInterpreter = challengeInterpreter;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> PostChallenge(ChallengeDto challenge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var settingsSection = configuration.GetSection("JDoodleSettings");
                    var jdoodleSettings = settingsSection.Get<JDoodleSettings>();

                    var isSuccess = await challengeInterpreter.Interpret(jdoodleSettings, challenge);
                    return Ok(isSuccess);
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return ValidationProblem();
        }


    }
}