using Newtonsoft.Json;
using Forecast.Core.Utils;

namespace Forecast.Domain.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AirQualityData
    {
        [JsonProperty("dt")]
        public long DateTimeStamp { get; set; }
        [JsonProperty("main.aqi")]
        public float AQI { get; set; }
        [JsonProperty("components.co")]
        public float CO { get; set; }

        [JsonProperty("components.o3")]
        public float O3 { get; set; }
        [JsonProperty("components.no2")]
        public float NO2 { get; set; }
        [JsonProperty("components.pm10")]
        public float PM10 { get; set; }

    }
}
