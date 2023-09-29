using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Api.Commands.Responses;

namespace Syslog.Api.Commands.Requests
{
    public class FinishDeliveryRequest : IRequest<FinishDeliveryResponse>
    {
        [Required]
        public Guid DeliveryId { get; set; }

        [Required]
        public string? Receiver { get; set; }
    }
}