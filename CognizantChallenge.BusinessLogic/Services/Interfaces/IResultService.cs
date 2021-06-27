using CognizantChallenge.ComBusinessLogicmon.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Interface containing methods for operations on Task type
    /// </summary>
    public interface IResultService
    {
        /// <summary>
        /// Method returns top 3 users with maximum successful submissions
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Result>> GetTopThreeResultsAsync();
    }
}
