using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Factories.Interfaces;
using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.Core.Database.Entities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Helpers.Implementations
{
    public class ChallengeInterpreter : IChallengeInterpreter
    {
        private readonly IJdoodleService jdoodleService;
        private readonly IJdoodleRequestFactory jdoodleRequestFactory;
        private readonly ITaskService taskService;
        private readonly IChallengeService challengeService;
        private readonly IConverter<ChallengeDto, Challenge> challengeConverter;

        public ChallengeInterpreter(
             IJdoodleService jdoodleService,
             IJdoodleRequestFactory jdoodleRequestFactory,
             ITaskService taskService,
             IChallengeService challengeService,
             IConverter<ChallengeDto, Challenge> challengeConverter)
        {
            this.jdoodleService = jdoodleService;
            this.jdoodleRequestFactory = jdoodleRequestFactory;
            this.taskService = taskService;
            this.challengeService = challengeService;
            this.challengeConverter = challengeConverter;
        }
        public async Task<bool> Interpret(JDoodleSettings settings, ChallengeDto challengeDto)
        {
            var task = await taskService.GetTaskByIdAsync(challengeDto.TaskId);

            var jdoodleRequest = jdoodleRequestFactory.CreateJDoodleRequest(settings, challengeDto, task.InputParameter);
            var response = await jdoodleService.CallAsync(jdoodleRequest);

            var isSuccess = CheckResponse(response, task);

            var challenge = challengeConverter.Convert(challengeDto);
            challenge.IsSuccess = isSuccess;
            await challengeService.InsertChallenge(challenge);

            return isSuccess;
        }

        private bool CheckResponse(JDoodleResponse response, Core.Database.Entities.Task task)
        {
            Enum.TryParse(response.StatusCode, out HttpStatusCode statusCode);
            return statusCode == HttpStatusCode.OK && task.OutputParameter == response.Output;
        }
    }
}
