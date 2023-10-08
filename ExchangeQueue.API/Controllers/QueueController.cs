using ExchangeQueue.API.ViewModels.Queues;
using ExchangeQueue.Domain.Dtos.Queues;
using ExchangeQueue.Domain.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeQueue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _service;
        private readonly ILogger<QueueController> _logger;

        public QueueController(IQueueService service, ILogger<QueueController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] QueueViewModel model)
        {
            await _service.PostAsync(model.Adapt<QueueDtoRequest>());
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _service.GetAsync());
    }
}