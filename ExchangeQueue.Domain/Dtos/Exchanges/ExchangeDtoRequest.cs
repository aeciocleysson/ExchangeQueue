using ExchangeQueue.Domain.Enum;

namespace ExchangeQueue.Domain.Dtos.Exchanges
{
    public class ExchangeDtoRequest
    {
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
    }
}