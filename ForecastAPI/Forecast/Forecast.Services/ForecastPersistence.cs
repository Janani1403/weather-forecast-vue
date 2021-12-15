using Newtonsoft.Json;
using Forecast.Domain.Abstractions;
using Forecast.Domain.Models;
using static Forecast.Core.Constants.Constants;
using Forecast.Core.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using Forecast.Core.Exceptions;

namespace Forecast.Services
{
    public class ForecastPersistence : HttpClient, IForecastPersistence
    {
        public ForecastPersistence()
        {
        }
        /// <summary>
        /// Private method calling openweather api
        /// </summary>
        /// <param name="url">complete url with Parameters</param>
        /// <returns>JSON stream - will be formatted in specific functions</returns>
        /// <exception cref="PersistenceException"></exception>
        private async static Task<string> GetAsyncResponse(string url)
        {
            try
            {
                using HttpClient httpClient = new ();
                return (await httpClient.GetAsync(new Uri(url)))
                    .Content
                    .ReadAsStringAsync()
                    .Result;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }
        /// <summary>
        /// Persistence method to retrieve forecast based on city
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Model object</returns>
        /// <exception cref="PersistenceException"></exception>
        public async Task<ForecastAllData> GetForecastByCity(string city)
        {
            try
            {
                var response = await GetAsyncResponse(string.Concat(URL_CITY, city));
                var jsonResponse = JsonConvert.DeserializeObject<ForecastAllData>(response);
              
                return jsonResponse;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }
        /// <summary>
        /// Persistence method to retrieve forecast based on zipcode
        /// </summary>
        /// <param name="zipCode">zipcode value</param>
        /// <returns>Model object</returns>
        /// <exception cref="PersistenceException"></exception>
        public async Task<ForecastAllData> GetForecastByZipCode(string zipCode)
        {
            try
            {
                var response = await GetAsyncResponse(string.Concat(URL_ZIPCODE, zipCode));
                var jsonResponse = JsonConvert.DeserializeObject<ForecastAllData>(response);

                return jsonResponse;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }
        /// <summary>
        /// Persistence method to retrieve air pollution data (additional)
        /// </summary>
        /// <param name="city">City name</param>
        /// <returns>Model object</returns>
        /// <exception cref="PersistenceException"></exception>
        public async Task<AirQualityAllData> GetAirQuality(string city)
        {
            var coordinates = JsonConvert.DeserializeObject<Coordinates>(await GetAsyncResponse(string.Concat(URL_GEOCODE, city)));
            try
            {
                var response = await GetAsyncResponse(
                    string.Concat(URL_AQI, "&lat=", coordinates.Latitude, "&lon=", coordinates.Longitude));
                var jsonResponse = JsonConvert.DeserializeObject<AirQualityAllData>(response);
                return jsonResponse;
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }
    }
}
