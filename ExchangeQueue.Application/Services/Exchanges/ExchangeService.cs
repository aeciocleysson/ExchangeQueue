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
        private readonly IExchangeRepository _repository;

        public ExchangeService(IExchangeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Exchange>> GetAsync() => await _repository.GetAsync();

        public async Task<Exchange> PostAsync(ExchangeDtoRequest model)
        {
            if (model is not null)
            {
                try
                {
                    var factory = new ConnectionFactory() { HostName = "host.docker.internal" };
                    using var connection = factory.CreateConnection();

                    using var channel = connection.CreateModel();

                    var exchange = model.Adapt<Exchange>();

                    var response = await _repository.PostAsync(exchange);

                    channel.ExchangeDeclare(model.Name, type: model.Type.ToString().ToLower());

                    return response;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
    }
}