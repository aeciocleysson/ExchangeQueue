using ExchangeQueue.Domain.Dtos.Queues;
using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Services
{
    public interface IQueueService
    {
        Task<Queue> PostAsync(QueueDtoRequest model);
        Task<List<Queue>> GetAsync();
    }
}