using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Enums;
using CognizantChallenge.BusinessLogic.Factories.Interfaces;
using CognizantChallenge.BusinessLogic.Helpers.Implementations;
using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.BusinessLogic.Services.Interfaces;
using CognizantChallenge.Core.Database.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CognizantChallenge.Tests.Helpers
{
    public class ChallengeInterpreterTests
    {
        private readonly IChallengeInterpreter challengeInterpreter;
        private readonly Mock<IJdoodleService> jdoodleServiceMock;
        private readonly Mock<IJdoodleRequestFactory> jdoodleRequestFactoryMock;
        private readonly Mock<ITaskService> taskServiceMock;
        private readonly Mock<IChallengeService> challengeServiceMock;
        private readonly Mock<IConverter<ChallengeDto, Challenge>> challengeConverterMock;

        public ChallengeInterpreterTests()
        {
            jdoodleServiceMock = new Mock<IJdoodleService>();
            jdoodleRequestFactoryMock = new Mock<IJdoodleRequestFactory>();
            taskServiceMock = new Mock<ITaskService>();
            challengeServiceMock = new Mock<IChallengeService>();
            challengeConverterMock = new Mock<IConverter<ChallengeDto, Challenge>>();
            challengeInterpreter = new ChallengeInterpreter(
                jdoodleServiceMock.Object,
                jdoodleRequestFactoryMock.Object,
                taskServiceMock.Object,
                challengeServiceMock.Object,
                challengeConverterMock.Object);
        }

        [Test]
        public void Interpret_ShouldReturnTrue_IfSubmissionIsSuccessful()
        {
            // Arrange
            var settings = new JDoodleSettings
            {
                ClientId = "11111111",
                ClientSecret = "22222222"
            };

            var challengeDto = new ChallengeDto
            {
                Language = Language.Csharp,
                Solution = @"using System;

                        public class Test {
                          public static void Main() {
                            int input = 0;
                            Console.Write(Factorial(input));
                          }

                          public static int Factorial(int n) {
                            if (n < 1)
			                    return 1;
		                    else
		                    return n * Factorial(n - 1);
                          }
                        }",
                TaskId = 1,
                Username = "John"
            };

            var task = new Core.Database.Entities.Task
            {
                OutputParameter = "30",
                TaskName = "TaskName",
                InputParameter = "15",
                Description = "Description",
                Id = 1
            };

            var jdoodleResponse = new JDoodleResponse
            {
                StatusCode = "200",
                Output = "30",
                CpuTime = "0.01",
                Memory = "12354"
            };

            var challenge = new Challenge
            {
                TaskId = 1,
                Username = "John"
            };

            taskServiceMock
                .Setup(x => x.GetTaskByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(task);
            jdoodleRequestFactoryMock
                .Setup(x => x.CreateJDoodleRequest(It.IsAny<JDoodleSettings>(), It.IsAny<ChallengeDto>(), It.IsAny<string>()))
                .Returns(It.IsAny<JDoodleRequest>());
            jdoodleServiceMock
                .Setup(x => x.CallAsync(It.IsAny<JDoodleRequest>()))
                .ReturnsAsync(jdoodleResponse);
            challengeConverterMock
                .Setup(x => x.Convert(It.IsAny<ChallengeDto>()))
                .Returns(challenge);
            challengeServiceMock
                .Setup(x => x.InsertChallenge(It.IsAny<Challenge>()))
                .Verifiable();
            // Act
            var result = challengeInterpreter.Interpret(settings, challengeDto).GetAwaiter().GetResult();

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Interpret_ShouldReturnFalse_IfSubmissionIsNotSuccessful()
        {
            // Arrange
            var settings = new JDoodleSettings
            {
                ClientId = "11111111",
                ClientSecret = "22222222"
            };

            var challengeDto = new ChallengeDto
            {
                Language = Language.Csharp,
                Solution = @"using System;

                        public class Test {
                          public static void Main() {
                            int input = 0;
                            Console.Write(Factorial(input));
                          }

                          public static int Factorial(int n) {
                            if (n < 1)
			                    return 1;
		                    else
		                    return n * Factorial(n - 1);
                          }
                        }",
                TaskId = 1,
                Username = "John"
            };

            var task = new Core.Database.Entities.Task
            {
                OutputParameter = "30",
                TaskName = "TaskName",
                InputParameter = "15",
                Description = "Description",
                Id = 1
            };

            var jdoodleResponse = new JDoodleResponse
            {
                StatusCode = "200",
                Output = "50",
                CpuTime = "0.01",
                Memory = "12354"
            };

            var challenge = new Challenge
            {
                TaskId = 1,
                Username = "John"
            };

            taskServiceMock
                .Setup(x => x.GetTaskByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(task);
            jdoodleRequestFactoryMock
                .Setup(x => x.CreateJDoodleRequest(It.IsAny<JDoodleSettings>(), It.IsAny<ChallengeDto>(), It.IsAny<string>()))
                .Returns(It.IsAny<JDoodleRequest>());
            jdoodleServiceMock
                .Setup(x => x.CallAsync(It.IsAny<JDoodleRequest>()))
                .ReturnsAsync(jdoodleResponse);
            challengeConverterMock
                .Setup(x => x.Convert(It.IsAny<ChallengeDto>()))
                .Returns(challenge);
            challengeServiceMock
                .Setup(x => x.InsertChallenge(It.IsAny<Challenge>()))
                .Verifiable();
            // Act
            var result = challengeInterpreter.Interpret(settings, challengeDto).GetAwaiter().GetResult();

            // Assert
            result.Should().BeFalse();
        }
    }
}
