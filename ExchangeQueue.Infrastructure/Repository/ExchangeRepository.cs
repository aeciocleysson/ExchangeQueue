using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;
using MongoDB.Driver;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class ExchangeRepository : IExchangeRepository
    {
        private readonly IMongoContext _context;

        public ExchangeRepository(IMongoContext context)
        {
            _context = context;
        }

        public async Task<List<Exchange>> GetAsync()
        {
            return await _context.Exchange.Find(_ => true).ToListAsync();
        }

        public async Task PostAsync(Exchange exchange)
        {
            await _context.Exchange.InsertOneAsync(exchange);
        }
    }
}