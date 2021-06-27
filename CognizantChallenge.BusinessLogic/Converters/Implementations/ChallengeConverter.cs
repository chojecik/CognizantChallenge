using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.Core.Database.Entities;

namespace CognizantChallenge.BusinessLogic.Converters.Implementations
{
    public class ChallengeConverter : IConverter<ChallengeDto, Challenge>
    {
        public Challenge Convert(ChallengeDto source)
        {
            if (source == null)
            {
                return null;
            }

            return new Challenge
            {
                TaskId = source.TaskId,
                Username = source.Username
            };
        }
    }
}
