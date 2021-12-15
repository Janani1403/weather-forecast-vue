using Newtonsoft.Json;
using Forecast.Core.Utils;
using System;

namespace Forecast.Domain.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ForecastData
    {
        [JsonProperty("main.temp")]
        public float Temperature { get; set; }
        [JsonProperty("main.temp_min")]
        public float MinTemperature { get; set; }
        [JsonProperty("main.temp_max")]
        public float MaxTemperature { get; set; }
        [JsonProperty("main.humidity")]
        public float Humidity { get; set; }
        [JsonProperty("main.pressure")]
        public float Pressure { get; set; }
        [JsonProperty("weather.0.main")]
        public string WeatherMain { get; set; } = String.Empty;
        [JsonProperty("weather.0.description")]
        public string WeatherDescription { get; set; } = String.Empty;
        [JsonProperty("wind.speed")]
        public float WindSpeed { get; set; }
        [JsonProperty("wind.deg")]
        public float WindDegree { get; set; }
        [JsonProperty("wind.gust")]
        public float WindGust { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("rain.3h")]
        public float Rain { get; set; }
        [JsonProperty("dt_txt")]
        public string DateTime { get; set; } = String.Empty;
    }
}
