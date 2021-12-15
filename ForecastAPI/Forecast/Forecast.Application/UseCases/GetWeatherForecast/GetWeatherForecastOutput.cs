using Forecast.Domain.Models;
using System;
using System.Collections.Generic;

namespace Forecast.Application.UseCases.GetForecast
{
    public class GetForecastOutput
    {
        public List<ForecastData> WeatherDataItems { get; init; }
        public AirQualityAllData AirQualityDataItems { get; set; }
        public string City { get; init; } = String.Empty;
        public long Sunrise { get; init; }
        public long Sunset { get; init; }
    }
}
