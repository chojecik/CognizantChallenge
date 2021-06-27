using CognizantChallenge.BusinessLogic.Enums;
using CognizantChallenge.BusinessLogic.Factories.Implementations;
using CognizantChallenge.BusinessLogic.Factories.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CognizantChallenge.Tests.Factories
{
    public class JdoodleRequestFactoryTests
    {
        private readonly IJdoodleRequestFactory jdoodleRequestFactory;

        public JdoodleRequestFactoryTests()
        {
            jdoodleRequestFactory = new JDoodleRequestFactory();
        }

        [Test]
        public void CreateJDoodleRequest_ShouldReturnJDoodleRequest_WhenGivenAllInputs()
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

            var input = "2";
            var expectedResult = new JDoodleRequest
            {
                clientId = "11111111",
                clientSecret = "22222222",
                language = "csharp",
                script = @"using System;

                        public class Test {
                          public static void Main() {
                            int input = 2;
                            Console.Write(Factorial(input));
                          }

                          public static int Factorial(int n) {
                            if (n < 1)
			                    return 1;
		                    else
		                    return n * Factorial(n - 1);
                          }
                        }",
                versionIndex = "1"
            };

            // Act
            var result = jdoodleRequestFactory.CreateJDoodleRequest(settings, challengeDto, input);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
