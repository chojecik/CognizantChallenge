using CognizantChallenge.BusinessLogic.Converters.Implementations;
using CognizantChallenge.BusinessLogic.Converters.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using CognizantChallenge.Core.Database.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace CognizantChallenge.Tests.Converters
{
    public class ChallengesConverterTests
    {
        private readonly IConverter<ChallengeDto, Challenge> challengeConverter;

        public ChallengesConverterTests()
        {
            challengeConverter = new ChallengeConverter();
        }

        [Test]
        public void Convert_ShouldReturnChallengeObject_WhenGivenValidChallengeDtoObject()
        {
            // Arrange
            var challengeDto = new ChallengeDto
            {
                TaskId = 1,
                Username = "John"
            };

            var expectedResult = new Challenge
            {
                TaskId = 1,
                Username = "John"
            };

            // Act
            var result = challengeConverter.Convert(challengeDto);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Convert_ShouldReturnCNull_WhenGivenNullAsAnInput()
        {
            // Arrange

            // Act
            var result = challengeConverter.Convert(null);

            // Assert
            result.Should().BeNull();
        }
    }
}
