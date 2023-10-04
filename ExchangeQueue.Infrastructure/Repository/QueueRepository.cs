using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Infrastructure.Context;

namespace ExchangeQueue.Infrastructure.Repository
{
    public class QueueRepository : BaseRepository<Domain.Models.Queue, ExcahngeQueueContext>, IQueueRepository
    {
        public QueueRepository(ExcahngeQueueContext context) : base(context)
        {
        }
    }
}