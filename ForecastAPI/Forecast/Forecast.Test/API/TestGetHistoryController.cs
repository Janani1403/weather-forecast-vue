using Xunit;
using System.Threading.Tasks;
using MediatR;
using Forecast.API.Mapper;
using Microsoft.Extensions.Logging;
using Forecast.API.UseCases.GetForecast;
using Forecast.Application.UseCases.GetForecast;
using Moq;
using System.Threading;
using Forecast.Domain.Models;
using System.Collections.Generic;
using Forecast.API.UseCases.GetHistory;
using Forecast.Application.UseCases.GetHistory;
using Forecast.Domain.Entities;

namespace Forecast.Test.API
{
    public class TestGetHistoryController
    {
        [Fact]
        public async Task GetHistoryControllerSuccess() {
            var mediator = new Mock<IMediator>();
            var mapper = new DataMapper();
            var logger = new Mock<ILogger<GetHistoryController>>();
            GetHistoryOutput expectedResult = new() {
                History = new List<History>() { new History() { AccessedDateTime = "2021-20-11 09:00:00",
                    City = "test",
                    Humidity = 0,
                    Temperature = 0,
                    UserKey = "test" } }
            };
            mediator.Setup(x => x.Send(It.IsAny<GetHistoryInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            GetHistoryController controller = new ( mapper, mediator.Object, logger.Object);
            var output = await controller.GetHistoryByUser("test");
            Assert.NotNull(output);
            Assert.IsType<List<GetHistoryResponse>>(output);
        }
        [Fact]
        public async Task GetHistoryControllerFailure()
        {
            var mediator = new Mock<IMediator>();
            var mapper = new DataMapper();
            var logger = new Mock<ILogger<GetHistoryController>>();
            GetHistoryOutput expectedResult = null;
            mediator.Setup(x => x.Send(It.IsAny<GetHistoryInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            GetHistoryController controller = new(mapper, mediator.Object, logger.Object);
            var output = await controller.GetHistoryByUser("test");
            Assert.Empty(output);
        }
    }
}
