using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class ExchangeRepository : BaseRepository<Exchange>, IExchangeRepository
    {
        //private readonly IMongoContext _context;

        public ExchangeRepository(IMongoDBSettings settings) : base(settings)
        {
        }

        //public ExchangeRepository(IMongoContext context)
        //{
        //    _context = context;
        //}

        //public Task<List<Exchange>> GetAsync()
        //{
        //    //var response = await _context.Exchange.Find(_ => true).ToListAsync();
        //    //return response;

        //    throw new NotImplementedException();
        //}

        //public Task<Exchange> GetAsync(Guid id)
        //{
        //    //var response = await _context
        //    //                      .Exchange
        //    //                      .Find(_ => true)
        //    //                      .ToListAsync();

        //    throw new NotImplementedException();
        //}

        //public Task<Exchange> PostAsync(Exchange exchange)
        //{
        //    //try
        //    //{
        //    //    await _context.Exchange.InsertOneAsync(exchange);

        //    //    var response = await GetAsync(exchange.Id);

        //    //    if (response is not null)
        //    //        return response;
        //    //    else
        //    //        return null;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}
        //    throw new NotImplementedException();
        //}
    }
}