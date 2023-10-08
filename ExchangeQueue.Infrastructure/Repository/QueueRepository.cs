using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;
using MongoDB.Driver;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class QueueRepository : IQueueRepository
    {
        private readonly IMongoContext _context;

        public QueueRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<Queue>> GetAsync()
        {
            return await _context.Queue.Find(_ => true).ToListAsync();
        }

        public async Task PostAsync(Queue queue)
        {
            await _context.Queue.InsertOneAsync(queue);
        }
    }
}