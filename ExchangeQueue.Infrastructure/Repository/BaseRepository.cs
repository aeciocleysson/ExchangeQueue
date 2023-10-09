using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;
using MongoDB.Driver;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly IMongoCollection<T> _model;
        private readonly IMongoDBSettings _settings;

        public BaseRepository(IMongoDBSettings settings)
        {
            _settings = settings;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);

            _model = database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task<List<T>> GetAsync()
        {
            var response = await _model.Find(_ => true).ToListAsync();
            return response;
        }

        public async Task<T> GetAsync(Guid id)
        {
            var response = await _model.Find(_ => true).ToListAsync();

            return response.Where(w => w.Id == id).FirstOrDefault();
        }

        public async Task<T> PostAsync(T entity)
        {
            await _model.InsertOneAsync(entity);

            var response = await GetAsync(entity.Id);

            return response;
        }
    }
}