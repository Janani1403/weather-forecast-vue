using Forecast.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forecast.Domain.Abstractions
{
    public interface IHistoryPersistence<T> where T : BaseEntity
    {
        Task Create(T History);
        Task<IEnumerable<T>> GetAll(string userKey);
    }
}
