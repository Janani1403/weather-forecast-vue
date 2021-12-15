using Newtonsoft.Json;
using Forecast.Core.Utils;
using System.Collections.Generic;
using System;

namespace Forecast.Domain.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ForecastAllData
    {
        [JsonProperty("list")]
        public List<ForecastData> Items { get; set; }
        [JsonProperty("city.name")]
        public string City { get; set; } = String.Empty;
        [JsonProperty("city.sunrise")]
        public long Sunrise { get; set; } 
        [JsonProperty("city.sunset")]
        public long Sunset { get; set; } 

    }
}
