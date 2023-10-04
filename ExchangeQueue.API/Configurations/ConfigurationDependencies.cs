using ExchangeQueue.Application.Services.Exchanges;
using ExchangeQueue.Application.Services.Queues;
using ExchangeQueue.Domain.Interfaces;
using ExchangeQueue.Domain.Services;
using ExchangeQueue.Infrastructure.Context;
using ExchangeQueue.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExchangeQueue.API.Configurations
{
    public static class ConfigurationDependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IExchangeRepository, ExchangeRepository>();
            service.AddScoped<IQueueRepository, QueueRepository>();

            service.AddScoped<IExchangeService, ExchangeService>();
            service.AddScoped<IQueueService, QueueService>();

            service.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                       .AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
            });

            service.AddDbContext<ExcahngeQueueContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return service;
        }
    }
}