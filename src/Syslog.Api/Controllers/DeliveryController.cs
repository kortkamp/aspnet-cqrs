using MediatR;

using Microsoft.AspNetCore.Mvc;

using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;

namespace Syslog.Api.Controllers
{
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateDeliveryResponse>> Create(CreateDeliveryRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return Ok("ok");
        }
    }
}