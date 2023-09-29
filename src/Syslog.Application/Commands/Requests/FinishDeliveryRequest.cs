using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Application.Commands.Responses;

namespace Syslog.Application.Commands.Requests
{
    public class FinishDeliveryRequest : IRequest<FinishDeliveryResponse>
    {
        [Required]
        public Guid DeliveryId { get; set; }

        [Required]
        public string? Receiver { get; set; }
    }
}