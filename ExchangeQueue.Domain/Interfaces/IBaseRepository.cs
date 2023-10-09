using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(Guid id);

        Task<T> PostAsync(T entity);
    }
}