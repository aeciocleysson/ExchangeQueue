namespace ExchangeQueue.Domain.Models
{
    public class Queue : BaseModel
    {
        public string Name { get; private set; }
        public bool Durable { get; private set; }
        public bool Exclusive { get; private set; }
        public bool Autodelete { get; private set; }
        public string Arguments { get; private set; }
        public string Exchange { get; private set; }
        public string RountingKey { get; private set; }

        public Queue(string name, bool durable, bool exclusive, bool autodelete, string arguments, string exchange, string rountingKey)
        {
            Name = name;
            Durable = durable;
            Exclusive = exclusive;
            Autodelete = autodelete;
            Arguments = arguments;
            Exchange = exchange;
            RountingKey = rountingKey;
        }

        public Queue()
        {
                
        }
    }
}