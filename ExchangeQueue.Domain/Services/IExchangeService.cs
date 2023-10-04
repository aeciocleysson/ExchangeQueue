﻿using ExchangeQueue.Domain.Dtos.Exchanges;
using ExchangeQueue.Domain.Models;

namespace ExchangeQueue.Domain.Services
{
    public interface IExchangeService
    {
        Task<Exchange> PostAsync(ExchangeDtoRequest model);
        Task<List<Exchange>> GetAsync();
    }
}