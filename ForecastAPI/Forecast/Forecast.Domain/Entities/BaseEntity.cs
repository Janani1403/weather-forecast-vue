using System;

namespace Forecast.Domain.Entities
{
    public class BaseEntity
    {
        public string UserKey { get; init; } = String.Empty;
        public string AccessedDateTime { get; init; } = String.Empty;
    }
}
