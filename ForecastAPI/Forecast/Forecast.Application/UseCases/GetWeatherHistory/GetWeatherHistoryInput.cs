using MediatR;
using System;

namespace Forecast.Application.UseCases.GetHistory
{
    public class GetHistoryInput : IRequest<GetHistoryOutput>
    {
        public string UserKey { get; set; } = String.Empty;
    }
}
