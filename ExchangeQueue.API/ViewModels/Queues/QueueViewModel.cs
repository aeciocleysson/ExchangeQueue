namespace ExchangeQueue.API.ViewModels.Queues
{
    public class QueueViewModel
    {
        public string Name { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool Autodelete { get; set; }
        public string Arguments { get; set; }
        public string Exchange { get; set; }
        public string RountingKey { get; set; }
    }
}