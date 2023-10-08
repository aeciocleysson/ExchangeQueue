using ExchangeQueue.Domain.Enum;

namespace ExchangeQueue.Domain.Dtos.Exchanges
{
    public class ExchangeDtoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
    }
}