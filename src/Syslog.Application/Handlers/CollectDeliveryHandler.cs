using MediatR;

using Syslog.Application.Commands.Requests;
using Syslog.Application.Commands.Responses;
using Syslog.Application.Exceptions;
using Syslog.Domain.Interfaces.Repositories;

namespace Syslog.Application.DeliveryContext.Handlers
{
    public class CollectDeliveryHandler
        : IRequestHandler<CollectDeliveryRequest, CollectDeliveryResponse>
    {
        private readonly IPublisher _publisher;
        private readonly IDeliveryRepository _deliveryRepository;

        public CollectDeliveryHandler(IPublisher publisher, IDeliveryRepository deliveryRepository)
        {
            _publisher = publisher;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<CollectDeliveryResponse> Handle(
            CollectDeliveryRequest request,
            CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetById(request.DeliveryId) ?? throw new EntityNotFoundException();

            var collectEvent = delivery.Collect(request.DeliverymanId);

            await _deliveryRepository.Save(delivery);

            return new CollectDeliveryResponse()
            {
                Id = delivery.Id,
                Date = collectEvent.Date,
            };
        }
    }
}