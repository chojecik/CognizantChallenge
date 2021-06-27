using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.Core.Database.Entities;
using CognizantChallenge.DAL.Repositories.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace CognizantChallenge.BusinessLogic.Services.Implementations
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository challengeRepository;
        private readonly IConverter<ChallengeDto, Challenge> challengeConverter;

        public ChallengeService(
            IChallengeRepository challengeRepository,
            IConverter<ChallengeDto, Challenge> challengeConverter)
        {
            this.challengeRepository = challengeRepository;
            this.challengeConverter = challengeConverter;
        }

        public async Task InsertChallenge(Challenge entity)
        {
            if(entity != null)
            {
                await challengeRepository.AddAsync(entity);
            }
        }
    }
}
