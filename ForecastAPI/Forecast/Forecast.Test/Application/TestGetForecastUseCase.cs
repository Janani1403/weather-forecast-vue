using Forecast.Application.UseCases.GetForecast;
using Forecast.Domain.Abstractions;
using Forecast.Domain.Entities;
using Forecast.Domain.Models;
using Forecast.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Forecast.Test.Application
{
    public class TestGetForecastUseCase
    {
        [Fact]
        public async Task GetForecastUseCaseSuccess()
        {
            var forecastPersistence = new Mock<IForecastPersistence>();
            var historyPersistence = new Mock<IHistoryPersistence<History>>();
            forecastPersistence.Setup(p => p.GetForecastByCity(It.IsAny<string>()))
                .ReturnsAsync(new ForecastAllData()
                {
                    Items = new List<ForecastData>() { new ForecastData() },
                    City = "test",
                    Sunrise = 12345678,
                    Sunset = 1234567
                });
          
            historyPersistence.Setup(h => h.Create(It.IsAny<History>()));

            GetForecastUseCase useCase = new(forecastPersistence.Object, historyPersistence.Object);
            var response = await useCase.Handle(new GetForecastInput() { City = "test", UserKey = "test" }, System.Threading.CancellationToken.None);
            Assert.NotNull(response);
            Assert.IsType<GetForecastOutput>(response);
        }
        [Fact]
        public async Task GetForecastUseCaseFailure()
        {
            var forecastPersistence = new Mock<IForecastPersistence>();
            var historyPersistence = new Mock<IHistoryPersistence<History>>();

            forecastPersistence.Setup(p => p.GetForecastByCity(It.IsAny<string>()))
              .Returns<ForecastAllData>(null);
            historyPersistence.Setup(h => h.Create(It.IsAny<History>()));

            GetForecastUseCase useCase = new(forecastPersistence.Object, historyPersistence.Object);
            await Assert.ThrowsAsync<ArgumentException>(()=>useCase.Handle(new GetForecastInput() { City = "test", UserKey = "test" }, System.Threading.CancellationToken.None));
        }
    }
}
