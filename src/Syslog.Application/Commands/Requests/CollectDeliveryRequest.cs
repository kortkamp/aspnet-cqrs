using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Application.Commands.Responses;

namespace Syslog.Application.Commands.Requests
{
    public class CollectDeliveryRequest : IRequest<CollectDeliveryResponse>
    {
        [Required]
        public Guid DeliveryId { get; set; }

        [Required]
        public Guid DeliverymanId { get; set; }
    }
}