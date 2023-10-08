using ExchangeQueue.Domain.Dtos.Exchanges;
using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Services
{
    public interface IExchangeService
    {
        Task<ExchangeDtoResponse> PostAsync(ExchangeDtoRequest model);

        Task<List<Exchange>> GetAsync();

        Task<ExchangeDtoResponse> GetAsync(Guid id);
    }
}