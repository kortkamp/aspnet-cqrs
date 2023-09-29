using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Syslog.Data.Context;
using Syslog.Domain.Enums;

namespace Syslog.Api.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveryQueryController : ControllerBase
    {
        private readonly DataContext _context;

        public DeliveryQueryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] DeliveryState state)
        {
            return Ok(
                await _context.Deliveries
                .Where(x => x.State == state)
                .Select(x => new
                {
                    x.Id,
                    x.CreationDate,
                    x.Address,
                    x.State,
                })
                .ToListAsync());
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