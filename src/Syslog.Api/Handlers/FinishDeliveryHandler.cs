using MediatR;

using Syslog.Api.ApplicationExceptions;
using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Domain.Interfaces.Repositories;

namespace Syslog.Api.DeliveryContext.Handlers
{
    public class FinishDeliveryHandler
        : IRequestHandler<FinishDeliveryRequest, FinishDeliveryResponse>
    {
        private readonly IPublisher _publisher;
        private readonly IDeliveryRepository _deliveryRepository;

        public FinishDeliveryHandler(IPublisher publisher, IDeliveryRepository deliveryRepository)
        {
            _publisher = publisher;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<FinishDeliveryResponse> Handle(
            FinishDeliveryRequest request,
            CancellationToken cancellationToken)
        {
            var delivery = await _deliveryRepository.GetById(request.DeliveryId) ?? throw new EntityNotFoundException("Delivery was not found");

            var collectEvent = delivery.Finish(request.Receiver);

            await _deliveryRepository.Save(delivery);

            return new FinishDeliveryResponse()
            {
                Id = delivery.Id,
                Receiver = request.Receiver,
                Date = collectEvent.Date,
            };
        }
    }
}