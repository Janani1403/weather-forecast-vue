using Newtonsoft.Json;
using Forecast.Core.Utils;

namespace Forecast.Core.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class Coordinates
    {
        [JsonProperty("results.0.geometry.location.lat")]
        public float Latitude { get; set; }
        [JsonProperty("results.0.geometry.location.lng")]
        public float Longitude { get; set; }
    }
}
