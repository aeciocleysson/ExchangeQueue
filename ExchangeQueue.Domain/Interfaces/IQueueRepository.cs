using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Interfaces
{
    public interface IQueueRepository 
    {
        Task PostAsync(Queue queue);

        Task<List<Queue>> GetAsync();
    }
}