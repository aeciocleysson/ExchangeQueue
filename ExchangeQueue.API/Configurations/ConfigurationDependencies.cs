using ExchangeQueue.Application.Services.Exchanges;
using ExchangeQueue.Application.Services.Queues;
using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Services;
using ExchangeQueue.Infrastructure.Context;
using ExchangeQueue.Infrastructure.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExchangeQueue.API.Configurations
{
    public static class ConfigurationDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
            });

            #region Configurações do MongoDB

            service.Configure<MongoDBSettings>(configuration.GetSection(nameof(MongoDBSettings)));
            service.AddScoped<IMongoContext, MongoContext>();

            service.AddSingleton<IMongoDBSettings>(options => options.GetRequiredService<IOptions<MongoDBSettings>>().Value);

            service.AddScoped<IMongoDatabase>(options =>
            {
                var settings = configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
                var client = new MongoClient(settings.ConnectionString);
                return client.GetDatabase(settings.DatabaseName);
            });

            service.AddScoped<IQueueRepository, QueueRepository>();
            service.AddScoped<IExchangeRepository, ExchangeRepository>();

            service.AddScoped<IExchangeService, ExchangeService>();
            service.AddScoped<IQueueService, QueueService>();

            #endregion Configurações do MongoDB

            return service;
        }
    }
}