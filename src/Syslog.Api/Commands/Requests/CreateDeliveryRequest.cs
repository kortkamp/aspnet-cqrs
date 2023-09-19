using System.ComponentModel.DataAnnotations;
using MediatR;
using Syslog.Api.Commands.Responses;

namespace Syslog.Api.Commands.Requests
{
    public class CreateDeliveryRequest : IRequest<CreateDeliveryResponse>
    {
        [Required]
        public string OrderId { get; set; }
        [Required]
        public string Address { get; set; }
    }
}