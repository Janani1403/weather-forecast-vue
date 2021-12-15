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

namespace Forecast.Test.API
{
    public class TestGetForecastController
    {
        [Fact]
        public async Task GetForecastControllerByCitySuccess() {
            var mediator = new Mock<IMediator>();
            var mapper = new Mock<IDataMapper>();
            var logger = new Mock<ILogger<GetForecastController>>();
            GetForecastOutput expectedResult = new () { 
                AirQualityDataItems = new AirQualityAllData() { AQItems = new List<AirQualityData>() { } },
                WeatherDataItems = new List<ForecastData>() { },
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };
            GetForecastResponse response = new() {
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };
            mediator.Setup(x => x.Send(It.IsAny<GetForecastInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            mapper.Setup(x => x.MapGetForecastResponse(It.IsAny<GetForecastOutput>())).Returns(response);
            GetForecastController controller = new ( mapper.Object, mediator.Object, logger.Object);
            var output = await controller.GetForecastByCity("test","test");
            Assert.NotNull(output);
            Assert.IsType<GetForecastResponse>(output);
            Assert.Equal(expectedResult.City, output.City);        
            Assert.Equal(expectedResult.Sunrise, output.Sunrise);     
            Assert.Equal(expectedResult.Sunset, output.Sunset);     
        }
        [Fact]
        public async Task GetForecastControllerByCityFailure()
        {
            var mediator = new Mock<IMediator>();
            var mapper = new Mock<IDataMapper>();
            var logger = new Mock<ILogger<GetForecastController>>();
            GetForecastOutput expectedResult = new()
            {
                AirQualityDataItems = new AirQualityAllData() { AQItems = new List<AirQualityData>() { } },
                WeatherDataItems = new List<ForecastData>() { },
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };
            
            mediator.Setup(x => x.Send(It.IsAny<GetForecastInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            mapper.Setup(x => x.MapGetForecastResponse(It.IsAny<GetForecastOutput>())).Returns((GetForecastResponse)null);
            GetForecastController controller = new(mapper.Object, mediator.Object, logger.Object);
            var output = await controller.GetForecastByCity("test", "test");
            Assert.Null(output);
        }
        [Fact]
        public async Task GetForecastControllerByZipcodeSuccess()
        {
            var mediator = new Mock<IMediator>();
            var mapper = new Mock<IDataMapper>();
            var logger = new Mock<ILogger<GetForecastController>>();
            GetForecastOutput expectedResult = new()
            {
                AirQualityDataItems = new AirQualityAllData() { AQItems = new List<AirQualityData>() { } },
                WeatherDataItems = new List<ForecastData>() { },
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };
            GetForecastResponse response = new()
            {
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };
            mediator.Setup(x => x.Send(It.IsAny<GetForecastInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            mapper.Setup(x => x.MapGetForecastResponse(It.IsAny<GetForecastOutput>())).Returns(response);
            GetForecastController controller = new(mapper.Object, mediator.Object, logger.Object);
            var output = await controller.GetForecastByZipCode("test", "test");
            Assert.NotNull(output);
            Assert.IsType<GetForecastResponse>(output);
            Assert.Equal(expectedResult.City, output.City);
            Assert.Equal(expectedResult.Sunrise, output.Sunrise);
            Assert.Equal(expectedResult.Sunset, output.Sunset);
        }
        [Fact]
        public async Task GetForecastControllerByZipcodeFailure()
        {
            var mediator = new Mock<IMediator>();
            var mapper = new Mock<IDataMapper>();
            var logger = new Mock<ILogger<GetForecastController>>();
            GetForecastOutput expectedResult = new()
            {
                AirQualityDataItems = new AirQualityAllData() { AQItems = new List<AirQualityData>() { } },
                WeatherDataItems = new List<ForecastData>() { },
                City = "test",
                Sunrise = 12345678,
                Sunset = 12345678
            };

            mediator.Setup(x => x.Send(It.IsAny<GetForecastInput>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);
            mapper.Setup(x => x.MapGetForecastResponse(It.IsAny<GetForecastOutput>())).Returns<GetForecastResponse>(null);
            GetForecastController controller = new(mapper.Object, mediator.Object, logger.Object);
            var output = await controller.GetForecastByZipCode("test", "test");
            Assert.Null(output);
        }
    }
}
