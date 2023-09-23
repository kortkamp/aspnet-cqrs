using System.ComponentModel.DataAnnotations;

using MediatR;

using Syslog.Api.Commands.Responses;

namespace Syslog.Api.Commands.Requests
{
    public class CollectDeliveryRequest : IRequest<CollectDeliveryResponse>
    {
        [Required]
        public Guid DeliveryId { get; set; }

        [Required]
        public Guid DeliverymanId { get; set; }
    }
}