using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Application.Commands.Responses;

namespace Syslog.Application.Commands.Requests
{
    public class CreateDeliveryRequest : IRequest<CreateDeliveryResponse>
    {
        [Required]
        public required string OrderId { get; set; }

        [Required]
        public required string Address { get; set; }
    }
}