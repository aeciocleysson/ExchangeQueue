using ExchangeQueue.API.ViewModels.Exchanges;
using ExchangeQueue.Domain.Dtos.Exchanges;
using ExchangeQueue.Domain.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeQueue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> _logger;
        private readonly IExchangeService _serrvice;

        public ExchangeController(ILogger<ExchangeController> logger, IExchangeService serrvice)
        {
            _logger = logger;
            _serrvice = serrvice;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ExchangeViewModel exchange)
        {
            await _serrvice.PostAsync(exchange.Adapt<ExchangeDtoRequest>());
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _serrvice.GetAsync());
    }
}