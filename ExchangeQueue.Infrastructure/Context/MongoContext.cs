using ExchangeQueue.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExchangeQueue.Infrastructure.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoDBSettings> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            _database = client.GetDatabase(config.Value.DatabaseName);
        }

        public IMongoCollection<Exchange> Exchange => _database.GetCollection<Exchange>("Exchange");
        public IMongoCollection<Queue> Queue => _database.GetCollection<Queue>("Queue");
    }
}