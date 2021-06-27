using CognizantChallenge.BusinessLogic.Models;

namespace CognizantChallenge.BusinessLogic.Factories.Interfaces
{
    /// <summary>
    /// Interface cointatining methods for creating new JDoodleRequest objects
    /// </summary>
    public interface IJdoodleRequestFactory
    {
        /// <summary>
        /// Method returning new JdoodleRequest object
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="challenge"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        JDoodleRequest CreateJDoodleRequest(JDoodleSettings settings, ChallengeDto challenge, string input);
    }
}
