using Forecast.Domain.Entities;
using System.Collections.Generic;

namespace Forecast.Application.UseCases.GetHistory
{
    public class GetHistoryOutput
    {
        public List<History> History { get; set; }
    }
}
