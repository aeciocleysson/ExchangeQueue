using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Interfaces
{
    public interface IExchangeRepository
    {
        Task<Exchange> PostAsync(Exchange exchange);

        Task<List<Exchange>> GetAsync();

        Task<Exchange> GetAsync(Guid id);
    }
}