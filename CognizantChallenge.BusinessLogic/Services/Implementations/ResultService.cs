using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.ComBusinessLogicmon.Models;
using CognizantChallenge.Core.Database.Entities;
using CognizantChallenge.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Services.Implementations
{
    public class ResultService : IResultService
    {
        private readonly IChallengeRepository challengeRepository;

        public ResultService(IChallengeRepository challengeRepository)
        {
            this.challengeRepository = challengeRepository;
        }

        public async Task<IEnumerable<Result>> GetTopThreeResultsAsync()
        {
            IEnumerable<Challenge> challenges = await challengeRepository.GetAllAsync();

            var results = challenges
                .Where(x => x.IsSuccess)
                .GroupBy(x => x.Username)
                .Select(x => new Result
                {
                    Username = x.Key,
                    SuccessfulSubmissions = x.Count()
                })
                .ToList();

            results.ForEach(x =>
            {
                x.SolvedTasks = challenges
                .Where(y => y.Username == x.Username &&
                            y.IsSuccess)
                .Select(y => y.Task.TaskName)
                .ToList();
            });

            return results
                .OrderByDescending(x => x.SuccessfulSubmissions)
                .Take(3);
        }
    }
}
