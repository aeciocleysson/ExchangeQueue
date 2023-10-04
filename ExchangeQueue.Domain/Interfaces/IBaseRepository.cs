using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> PostAsync(T entity);

        Task<T> PutAsync(T entity);

        Task<T> DeleteAsync(T entity);

        Task<T> GetAsync(T entity);

        Task<List<T>> GetAsync();

        Task<T> UpdateAsync(T entity);
    }
}