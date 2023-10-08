using ExchangeQueue.Domain.Enum;

namespace ExchangeQueue.API.ViewModels.Exchanges
{
    public class ExchangeViewModelResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ExchangeType Type { get; set; }
    }
}
