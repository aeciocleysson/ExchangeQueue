using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ExchangeQueue.Infrastructure.Repository
{
    public abstract class BaseRepository<T, TContext> : IBaseRepository<T> where T : BaseModel where TContext : DbContext
    {
        private readonly ExcahngeQueueContext _context;

        protected BaseRepository(ExcahngeQueueContext context)
        {
            _context = context;
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> PostAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<T> PutAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}