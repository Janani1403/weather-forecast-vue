using Forecast.Application.UseCases.GetForecast;
using Forecast.Application.UseCases.GetHistory;
using Forecast.Domain.Abstractions;
using Forecast.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Forecast.Test.Application
{
    public class TestGetHistoryUseCase
    {
        [Fact]
        public async Task GetHistoryUseCaseSuccess()
        {
            var historyPersistence = new Mock<IHistoryPersistence<History>>();
         
            historyPersistence.Setup(h => h.GetAll(It.IsAny<string>()))
                .ReturnsAsync(new List<History>() {
                new History(){ City= "test",
                Temperature=0,
                Humidity =0 } });

            GetHistoryUseCase useCase = new( historyPersistence.Object);
            var response = await useCase.Handle(new GetHistoryInput() { UserKey = "test" }, System.Threading.CancellationToken.None);
            Assert.NotNull(response);
            Assert.IsType<GetHistoryOutput>(response);
        }
        [Fact]
        public async Task GetHistoryUseCaseFailure()
        {
            var historyPersistence = new Mock<IHistoryPersistence<History>>();

            historyPersistence.Setup(h => h.GetAll(It.IsAny<string>()))
                .Returns<List<History>>(null);

            GetHistoryUseCase useCase = new( historyPersistence.Object);
            await Assert.ThrowsAsync<ArgumentException>(() => useCase.Handle(new GetHistoryInput() { UserKey = "test" }, System.Threading.CancellationToken.None));

        }
    }
}
