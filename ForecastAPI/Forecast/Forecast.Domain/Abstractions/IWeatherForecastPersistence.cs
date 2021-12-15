using Forecast.Domain.Models;
using System.Threading.Tasks;

namespace Forecast.Domain.Abstractions
{
    public interface IForecastPersistence
    {
        Task<ForecastAllData> GetForecastByCity(string city);
        Task<ForecastAllData> GetForecastByZipCode(string zipCode);
        Task<AirQualityAllData> GetAirQuality(string city);
    }
}
