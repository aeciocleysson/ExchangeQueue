using ExchangeQueue.Domain.Dtos.Exchanges;
using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Domain.Services;
using Mapster;
using RabbitMQ.Client;

namespace ExchangeQueue.Application.Services.Exchanges
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeService(IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
        }

        public async Task<List<Exchange>> GetAsync() => await _exchangeRepository.GetAsync();

        public async Task PostAsync(ExchangeDtoRequest model)
        {
            if (model is not null)
            {
                try
                {
                    //var factory = new ConnectionFactory() { HostName = "host.docker.internal" };
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using var connection = factory.CreateConnection();

                    using var channel = connection.CreateModel();

                    var exchange = model.Adapt<Exchange>();

                    await _exchangeRepository.PostAsync(exchange);

                    channel.ExchangeDeclare(model.Name, type: model.Type.ToString().ToLower());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }          
        }
    }
}