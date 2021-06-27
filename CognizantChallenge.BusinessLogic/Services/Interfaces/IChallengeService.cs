using CognizantChallenge.Core.Database.Entities;
using Task = System.Threading.Tasks.Task;

namespace CognizantChallenge.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods for operations on Challenge type
    /// </summary>
    public interface IChallengeService
    {
        /// <summary>
        /// Method used for inserting new challenge
        /// </summary>
        /// <param name="challenge"></param>
        /// <returns></returns>
        Task InsertChallenge(Challenge challenge);
    }
}
