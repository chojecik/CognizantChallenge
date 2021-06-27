using CognizantChallenge.BusinessLogic.Models;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Helpers.Interfaces
{
    /// <summary>
    /// Interface for calling external JDoodle API
    /// </summary>
    public interface IJdoodleService
    {
        /// <summary>
        /// Method used for sending REST request to Jdoodle API
        /// </summary>
        /// <returns></returns>
        Task<JDoodleResponse> CallAsync(JDoodleRequest jDoodleRequest);
    }
}
