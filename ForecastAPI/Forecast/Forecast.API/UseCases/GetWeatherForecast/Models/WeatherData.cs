namespace Forecast.API.UseCases.GetForecast.Models
{
    public class WeatherData
    {
        public string CurrentDate { get; set; }
        public string WeatherMain{ get; set; }
        public string WeatherDescription { get; set; }
        public double Temperature{ get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
    }
}
