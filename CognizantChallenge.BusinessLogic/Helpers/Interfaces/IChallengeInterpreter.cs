using CognizantChallenge.BusinessLogic.Models;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Helpers.Interfaces
{
    /// <summary>
    /// Interface containing methods for interpreting submitted solutions
    /// </summary>
    public interface IChallengeInterpreter
    {
        /// <summary>
        /// Method determining whether the solution is correct
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="challenge"></param>
        Task<bool> Interpret(JDoodleSettings settings, ChallengeDto challenge);
    }
}
