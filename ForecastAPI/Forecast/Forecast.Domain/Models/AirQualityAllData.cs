using Newtonsoft.Json;
using Forecast.Core.Utils;
using System.Collections.Generic;

namespace Forecast.Domain.Models
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AirQualityAllData
    {
        [JsonProperty("list")]
        public List<AirQualityData> AQItems { get; set; }
    }
}
