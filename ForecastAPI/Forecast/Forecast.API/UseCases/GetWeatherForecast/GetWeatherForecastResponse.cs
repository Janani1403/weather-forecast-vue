using Forecast.API.UseCases.GetForecast.Models;
using Forecast.Domain.Models;
using System;

namespace Forecast.API.UseCases.GetForecast
{
    public class GetForecastResponse
    {
        public string City { get; init; } = String.Empty;
        public long Sunrise { get; init; }
        public long Sunset { get; init; }
        public double[] AverageTemperature { get; set; }
        public double[] AverageHumidity { get; set; }
        public AirQualityData AirQualityData { get; set; }
        public WeatherData[][] WeatherData { get; set; }
        public WeatherParameters[][] WeatherParameters { get; set; }
    }
}
