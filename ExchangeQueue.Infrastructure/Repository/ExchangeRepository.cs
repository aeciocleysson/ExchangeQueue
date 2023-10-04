using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Infrastructure.Context;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class ExchangeRepository : BaseRepository<Exchange, ExcahngeQueueContext>, IExchangeRepository
    {
        public ExchangeRepository(ExcahngeQueueContext context) : base(context)
        {
        }
    }
}