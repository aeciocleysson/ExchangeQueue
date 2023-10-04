using ExchangeQueue.Domain.Enum;

namespace ExchangeQueue.API.ViewModels.Exchanges
{
    public class ExchangeViewModel
    {
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
    }
}