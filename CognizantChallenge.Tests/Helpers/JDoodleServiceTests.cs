using CognizantChallenge.BusinessLogic.Helpers.Implementations;
using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using FluentAssertions;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CognizantChallenge.Tests.Helpers
{
    public class JDoodleServiceTests
    {
        [Test]
        public void CallAsync_ShouldReturnJDoodleResponse_IfCallFinishedWithSuccessCodeAndWithoutCompilationErrors()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'output':'377','statusCode':200,'memory':'13552','cpuTime':'0.01'}")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            JdoodleService jdoodleService = new JdoodleService(mockFactory.Object);

            var expectedResult = new JDoodleResponse
            {
                CpuTime = "0.01",
                Memory = "13552",
                Output = "377",
                StatusCode = "200"
            };

            // Act
            var result = jdoodleService.CallAsync(It.IsAny<JDoodleRequest>()).GetAwaiter().GetResult();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void CallAsync_ShouldReturnJDoodleResponse_IfCallFinishedWithSuccessCodeAndWithCompilationErrors()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'output':'Compilation failed: 1 error(s), 0 warnings\n\njdoodle.cs(14,17): error CS0103: The name `sFibonacci' does not exist in the current context\n','statusCode':200,'memory':null,'cpuTime':null}")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            JdoodleService jdoodleService = new JdoodleService(mockFactory.Object);

            var expectedResult = new JDoodleResponse
            {
                Output = "377",
                StatusCode = "Compilation failed: 1 error(s), 0 warnings\n\njdoodle.cs(14,17): error CS0103: The name `sFibonacci' does not exist in the current context\n"
            };

            // Act
            var result = jdoodleService.CallAsync(It.IsAny<JDoodleRequest>()).GetAwaiter().GetResult();

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public void CallAsync_ShouldReturnJDoodleResponse_IfCallFinishedWithoutSuccessCode()
        {
            // Arrange
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("{'output':'Unauthorized','statusCode':401,'memory':null,'cpuTime':null}")
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            JdoodleService jdoodleService = new JdoodleService(mockFactory.Object);
            var expectedResult = new JDoodleResponse
            {
                Output = "Unauthorized",
                StatusCode = "401"
            };

            // Act
            var result = jdoodleService.CallAsync(It.IsAny<JDoodleRequest>()).GetAwaiter().GetResult();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
