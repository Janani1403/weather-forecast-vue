using MediatR;
using Forecast.Domain.Abstractions;
using Forecast.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Forecast.Application.UseCases.GetHistory
{
    public class GetHistoryUseCase : IRequestHandler<GetHistoryInput, GetHistoryOutput>
    {
        private readonly IHistoryPersistence<History> _persistence;
        public GetHistoryUseCase
            (IHistoryPersistence<History> persistence)
        {
            _persistence = persistence;
        }
        /// <summary>
        /// Get History Data from History Persistence
        /// </summary>
        /// <param name="input">Model object</param>
        /// <param name="cancellationToken">(Internal)</param>
        /// <returns>Model object</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<GetHistoryOutput> Handle(GetHistoryInput input, CancellationToken cancellationToken)
        {
            try
            {
                return new GetHistoryOutput() { History = (await _persistence.GetAll(input.UserKey)).ToList() };
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
