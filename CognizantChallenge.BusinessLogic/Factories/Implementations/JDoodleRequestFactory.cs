using CognizantChallenge.BusinessLogic.Enums;
using CognizantChallenge.BusinessLogic.Extensions;
using CognizantChallenge.BusinessLogic.Factories.Interfaces;
using CognizantChallenge.BusinessLogic.Models;

namespace CognizantChallenge.BusinessLogic.Factories.Implementations
{
    public class JDoodleRequestFactory : IJdoodleRequestFactory
    {
        private readonly string oldLine = "int input = 0;";
        public JDoodleRequest CreateJDoodleRequest(JDoodleSettings settings, ChallengeDto challenge, string input)
        {
            challenge.Solution = ReplaceInputValue(challenge.Solution, input);
            return new JDoodleRequest
            {
                clientId = settings.ClientId,
                clientSecret = settings.ClientSecret,
                language = challenge.Language.GetDescription(),
                script = challenge.Solution,
                versionIndex = GetVersionIndex(challenge.Language)
            };
        }

        private string GetVersionIndex(Language language)
        {
            switch (language)
            {
                case Language.Csharp:
                    //mono 5.0.0
                    return "1";
                case Language.Java:
                    //JDK 10.0.1
                    return "2";
                default:
                    return null;
            }
        }

        private string ReplaceInputValue(string solution, string inputValue)
        {
            int.TryParse(inputValue, out int result);
            return solution.Replace(oldLine, $"int input = {result};");
        }
    }
}
