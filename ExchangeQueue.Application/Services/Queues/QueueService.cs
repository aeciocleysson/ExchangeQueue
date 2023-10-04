using ExchangeQueue.Domain.Dtos.Queues;
using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Models;
using ExchangeQueue.Domain.Services;
using Mapster;
using RabbitMQ.Client;

namespace ExchangeQueue.Application.Services.Queues
{
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _repository;

        public QueueService(IQueueRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Queue>> GetAsync() => await _repository.GetAsync();

        public async Task<Queue> PostAsync(QueueDtoRequest model)
        {
            if (model is not null)
            {
                var factory = new ConnectionFactory() { HostName = "host.docker.internal" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                var queueName = channel.QueueDeclare(model.Name,
                                                     model.Durable,
                                                     model.Exclusive,
                                                     model.Autodelete,
                                                     null);

                channel.QueueBind(model.Name, model.Exchange, model.RountingKey);

                var response = await _repository.PostAsync(model.Adapt<Queue>());

                return response;
            }
            else { return null; }
        }
    }
}