using ExchangeQueue.Domain.Models;
using MongoDB.Driver;

namespace ExchangeQueue.Infrastructure.Context
{
    public interface IMongoContext
    {
        IMongoCollection<Exchange> Exchange { get; }
        IMongoCollection<Queue> Queue { get; }
    }
}