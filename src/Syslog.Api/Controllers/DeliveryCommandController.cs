using MediatR;

using Microsoft.AspNetCore.Mvc;

using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Api.Contracts;
using Syslog.Api.Filters;

namespace Syslog.Api.Controllers
{
    [ApiResponseFilter]
    [ApiController]
    [Route("api/deliveries")]
    public class DeliveryCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<AppResponse<CreateDeliveryResponse>>> Create(CreateDeliveryRequest command)
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

        [HttpPost("finish")]
        public async Task<ActionResult<FinishDeliveryResponse>> Finish(FinishDeliveryRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}