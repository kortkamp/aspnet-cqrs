using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Data.Context;

namespace Syslog.Api.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DataContext _context;

        public DeliveryController(IMediator mediator, DataContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CreateDeliveryResponse>> Create(CreateDeliveryRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("collect")]
        public async Task<ActionResult<CollectDeliveryResponse>> Collect(CollectDeliveryRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("")]
        public async Task<ActionResult> Get(Guid id)
        {
            return Ok(await _context.Deliveries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(Guid id)
        {
            return Ok(
                await _context.Deliveries
                    .Include(x => x.Events)
                    .Select(x => new
                    {
                        x.Id,
                        x.CreationDate,
                        x.OrderId,
                        x.Address,
                        x.DeliverymanId,
                        events = x.Events.Select(e => new { e.Date, e.State }).ToList(),
                        x.State,
                    })
                    .FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}