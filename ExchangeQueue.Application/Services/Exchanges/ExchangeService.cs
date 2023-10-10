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

        public async Task<ExchangeDtoResponse> GetAsync(Guid id)
        {
            var response = (await _exchangeRepository.GetAsync(id)).Adapt<ExchangeDtoResponse>();

            if (response is not null)
                return response;
            else
                return null;
        }

        public async Task<ExchangeDtoResponse> PostAsync(ExchangeDtoRequest model)
        {
            if (model is not null)
            {
                try
                {
                    //var factory = new ConnectionFactory() { HostName = "host.docker.internal" };
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using var connection = factory.CreateConnection();

                    var exchange = model.Adapt<Exchange>();
                    using var channel = connection.CreateModel();

                    var request = (await _exchangeRepository.PostAsync(exchange)).Adapt<ExchangeDtoResponse>();

                    if (request is not null)
                    {
                        channel.ExchangeDeclare(model.Name, type: model.Type.ToString().ToLower());
                        return request;
                    }
                    else
                        return null;
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