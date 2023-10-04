using ExchangeQueue.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeQueue.Infrastructure.Context
{
    public class ExcahngeQueueContext : DbContext
    {
        public ExcahngeQueueContext(DbContextOptions<ExcahngeQueueContext> options) : base(options)
        {
        }

        public ExcahngeQueueContext()
        {
        }

        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Queue> Queues { get; set; }
    }
}