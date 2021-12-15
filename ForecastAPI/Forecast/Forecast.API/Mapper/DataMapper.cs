using Newtonsoft.Json;
using System;
using Forecast.API.UseCases.GetForecast;
using Forecast.API.UseCases.GetForecast.Models;
using Forecast.API.UseCases.GetHistory;
using Forecast.Application.UseCases.GetForecast;
using Forecast.Application.UseCases.GetHistory;
using Forecast.Core.Utils;
using System.Linq;
using System.Collections.Generic;
using Forecast.Core.Exceptions;

namespace Forecast.API.Mapper
{
    public class DataMapper : IDataMapper
    {
        public GetForecastResponse MapGetForecastResponse(GetForecastOutput output)
        {
            try
            {
                if (output != null && output.WeatherDataItems != null && output.WeatherDataItems.Any())
                {
                    double[] AverageTemperature = new double[5];
                    double[] AverageHumidity = new double[5];
                    WeatherData[][] weatherData = new WeatherData[5][];
                    WeatherParameters[][] weatherParameters = new WeatherParameters[5][];
                    GetForecastResponse response = new()
                    {
                        City = output.City,
                        Sunrise = output.Sunrise,
                        Sunset = output.Sunset,
                    };

                    response.AirQualityData = output.AirQualityDataItems.AQItems.FirstOrDefault();

                    for (int iCounter = 0; iCounter < 5; iCounter++)
                    {
                        //
                        DateTime dateTime = DateTime.Now.AddDays(iCounter).Date;
                        string date = dateTime.ToString("yyyy-dd-MM");

                        var filteredWeatherOutput = output.WeatherDataItems.Where(x => DateTime.Parse(x.DateTime).ToString("yyyy-dd-MM").Equals(date));
                        AverageTemperature[iCounter] =
                            Math.Round(filteredWeatherOutput.Select(x => x.Temperature).Average(), 2);
                        AverageHumidity[iCounter] =
                            Math.Round(filteredWeatherOutput.Select(x => x.Humidity).Average(), 2);
                        weatherData[iCounter] = filteredWeatherOutput.Select(x => new WeatherData { CurrentDate = x.DateTime, WeatherMain = x.WeatherMain, WeatherDescription = x.WeatherDescription, Temperature = Math.Round(x.Temperature, 2), Humidity = Math.Round(x.Humidity, 2), WindSpeed = Math.Round(x.WindSpeed, 2) }).ToArray();
                        weatherParameters[iCounter] = filteredWeatherOutput.Select(x => new WeatherParameters { CurrentDate = x.DateTime, MinTemperature = Math.Round(x.MinTemperature, 2), MaxTemperature = Math.Round(x.MaxTemperature, 2), Pressure = Math.Round(x.Pressure, 2), Visibility = x.Visibility, WindDegree = Math.Round(x.WindDegree, 2), WindGust = Math.Round(x.WindGust, 2) }).ToArray();

                    }
                    response.AverageHumidity = AverageHumidity;
                    response.AverageTemperature = AverageTemperature;
                    response.WeatherData = weatherData;
                    response.WeatherParameters = weatherParameters;
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
            return null;
        }

        public List<GetHistoryResponse> MapGetHistoryResponse(GetHistoryOutput output)
        {
            if (output != null && output.History != null && output.History.Any())
            {
                return output.History.Select(x => new GetHistoryResponse
                {
                    City = x.City,
                    Date = x.Date,
                    AccessedDateTime = x.AccessedDateTime,
                    Humidity = x.Humidity,
                    Id = x.Id,
                    Temperature = x.Temperature
                }).ToList();
            }
            return new List<GetHistoryResponse>();
        }
    }
}
