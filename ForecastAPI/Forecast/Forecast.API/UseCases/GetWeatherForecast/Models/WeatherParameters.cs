namespace Forecast.API.UseCases.GetForecast.Models
{
    public class WeatherParameters
    {
        public string CurrentDate { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Pressure { get; set; }
        public double WindDegree { get; set; }
        public double WindGust { get; set; }
        public double Visibility { get; set; }
      
    }
}
