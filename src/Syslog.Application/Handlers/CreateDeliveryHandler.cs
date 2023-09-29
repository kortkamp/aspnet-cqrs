using MediatR;

using Syslog.Application.Commands.Requests;
using Syslog.Application.Commands.Responses;
using Syslog.Application.Events;
using Syslog.Application.Providers.CodeGenerator;
using Syslog.Domain.Entities;
using Syslog.Domain.Interfaces.Repositories;

namespace Syslog.Application.DeliveryContext.Handlers
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryRequest, CreateDeliveryResponse>
    {
        private readonly ICodeGenerator _codeGenerator;
        private readonly IPublisher _publisher;
        private readonly IDeliveryRepository _deliveryRepository;

        public CreateDeliveryHandler(ICodeGenerator codeGenerator, IPublisher publisher, IDeliveryRepository deliveryRepository)
        {
            _publisher = publisher;
            _codeGenerator = codeGenerator;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<CreateDeliveryResponse> Handle(
          CreateDeliveryRequest request,
          CancellationToken cancellationToken)
        {
            var code = await _codeGenerator.Generate();
            var delivery = new Delivery(code, request.OrderId, request.Address);

            var result = new CreateDeliveryResponse
            {
                Id = delivery.Id,
                Code = delivery.Code,
                CreationDate = delivery.CreationDate,
            };

            await _deliveryRepository.Save(delivery);

            _ = _publisher.Publish(
              new DeliveryCreatedEvent { Address = delivery.Address, Code = delivery.Code },
              cancellationToken);

            return result;
        }
    }
}