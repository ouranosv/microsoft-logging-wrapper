using System;
using Common.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using Xunit;

namespace Microsoft.Logging.Wrapper.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void LogInformation_WithMessageAndArgs_ShouldCallLogInformationMethodOfMicrosoftExtensionsLoggingPackage()
        {
            //arrange
            var microsoftLogger = new Mock<ILogger<Logger>>();
            var logger = new Logger(microsoftLogger.Object);

            //act
            logger.LogInformation("test {0}", 1);

            //assert
            microsoftLogger.Verify(
                t => t.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<FormattedLogValues>(v => v.ToString().Equals("test 1")),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            ), Times.Once);
        }

        [Fact]
        public void LogError_WithMessageAndArgs_ShouldCallLogErrorMethodOfMicrosoftExtensionsLoggingPackage()
        {
            //arrange
            var microsoftLogger = new Mock<ILogger<Logger>>();
            var logger = new Logger(microsoftLogger.Object);

            //act
            logger.LogError("test {0}", 1);

            //assert
            microsoftLogger.Verify(
                t => t.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<FormattedLogValues>(v => v.ToString().Equals("test 1")),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            ), Times.Once);
        }
    }
}
