namespace ExchangeQueue.Domain.Enum
{
    public enum ExchangeType : int
    {
        direct = 0,
        fanout = 1,
        topic = 2,
        headers = 3
    }
}