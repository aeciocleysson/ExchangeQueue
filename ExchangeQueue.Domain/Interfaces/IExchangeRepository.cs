using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Interfaces
{
    public interface IExchangeRepository
    {
        Task PostAsync(Exchange exchange);

        Task<List<Exchange>> GetAsync();
    }
}