using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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
            var response = await _context.Exchange.Find(_ => true).ToListAsync();
            return response;
        }

        public async Task<Exchange> GetAsync(Guid id)
        {
            var response = await _context
                                  .Exchange
                                  .Find(_ => true)
                                  .ToListAsync();

            return response.Where(w => w.Id == id).FirstOrDefault();
        }

        public async Task<Exchange> PostAsync(Exchange exchange)
        {
            try
            {
                await _context.Exchange.InsertOneAsync(exchange);

                var response = await GetAsync(exchange.Id);

                if (response is not null)
                    return response;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}