using System;

namespace Forecast.API.UseCases.GetHistory
{
    public class GetHistoryResponse
    {
        public int Id { get; init; }
        public string Date { get; init; } = String.Empty;
        public string AccessedDateTime { get; init; } = String.Empty;
        public string City { get; init; } = String.Empty;
        public float Temperature { get; init; }
        public float Humidity { get; init; }
    }
}
