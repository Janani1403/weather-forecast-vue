using MediatR;
using System;

namespace Forecast.Application.UseCases.GetForecast
{
    public class GetForecastInput : IRequest<GetForecastOutput>
    {
        public string City { get; init; } = String.Empty;
        public string ZipCode { get; init; } = String.Empty;
        public string UserKey { get; init; } = String.Empty;
    }
}
