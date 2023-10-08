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
        private readonly IExchangeService _service;

        public ExchangeController(ILogger<ExchangeController> logger, IExchangeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ExchangeViewModel exchange)
        {
            var response = (await _service.PostAsync(exchange.Adapt<ExchangeDtoRequest>())).Adapt<ExchangeViewModelResponse>();
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _service.GetAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = (await _service.GetAsync(id)).Adapt<ExchangeViewModelResponse>();
            return Ok(response);
        }
    }
}