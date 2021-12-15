using Forecast.API.UseCases.GetForecast;
using Forecast.API.UseCases.GetHistory;
using Forecast.Application.UseCases.GetForecast;
using Forecast.Application.UseCases.GetHistory;
using System.Collections.Generic;

namespace Forecast.API.Mapper
{
    public interface IDataMapper
    {
        GetForecastResponse MapGetForecastResponse(GetForecastOutput output);
        List<GetHistoryResponse> MapGetHistoryResponse(GetHistoryOutput output);
    }
}
