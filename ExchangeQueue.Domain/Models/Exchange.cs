using ExchangeQueue.Domain.Enum;

namespace ExchangeQueue.Domain.Models
{
    public class Exchange : BaseModel
    {
        public string Name { get; private set; }
        public ExchangeType Type { get; private set; }

        public Exchange(string name, ExchangeType type)
        {
            Name = name;
            Type = type;
        }

        public Exchange()
        {
            
        }
    }
}