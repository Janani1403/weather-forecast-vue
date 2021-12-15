using MediatR;
using Forecast.Domain.Abstractions;
using Forecast.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Threading;

namespace Forecast.Application.UseCases.GetForecast
{
    public class GetForecastUseCase : IRequestHandler<GetForecastInput, GetForecastOutput>
    {
        private readonly IForecastPersistence _forecastPersistence;
        private readonly IHistoryPersistence<History> _historyPersistence;
        public GetForecastUseCase(IForecastPersistence forecastPersistence,
            IHistoryPersistence<History> historyPersistence)
        {
            _forecastPersistence = forecastPersistence;
            _historyPersistence = historyPersistence;
        }
        /// <summary>
        /// Get Forecast Data from Forecast Persistence
        /// Add new entry to History table - only basic parameters
        /// </summary>
        /// <param name="input">Model object</param>
        /// <param name="cancellationToken">(Internal)</param>
        /// <returns>Model object</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<GetForecastOutput> Handle(GetForecastInput input, CancellationToken cancellationToken)
        {
            GetForecastOutput output;
            try
            {
                if (String.IsNullOrEmpty(input.ZipCode))
                {
                    var weatherResponse = await _forecastPersistence.GetForecastByCity(input.City);
                    output = new GetForecastOutput { WeatherDataItems = weatherResponse.Items, City = weatherResponse.City, Sunset = weatherResponse.Sunset, Sunrise = weatherResponse.Sunrise };
                }
                else
                {
                    var weatherResponse = await _forecastPersistence.GetForecastByZipCode(input.ZipCode);
                    output = new GetForecastOutput { WeatherDataItems = weatherResponse.Items, City = weatherResponse.City, Sunset = weatherResponse.Sunset, Sunrise = weatherResponse.Sunrise };
                }
                var airQualityResponse = await _forecastPersistence.GetAirQuality(output.City);
                output.AirQualityDataItems = airQualityResponse;
                if (output.WeatherDataItems != null && output.WeatherDataItems.Count > 0)
                {
                    var weatherNow = output.WeatherDataItems.FirstOrDefault();
                    if (weatherNow != null)
                    {
                        History history = new()
                        {
                            AccessedDateTime = DateTime.Now.ToString("yyyy-dd-MM hh:mm:ss"),
                            City = output.City,
                            Date = weatherNow.DateTime,
                            Humidity = weatherNow.Humidity,
                            Temperature = weatherNow.Temperature,
                            UserKey = input.UserKey
                        };
                        await _historyPersistence.Create(history);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return output;
        }
    }
}
