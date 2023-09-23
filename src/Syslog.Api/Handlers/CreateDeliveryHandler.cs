using MediatR;

using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Api.Events;
using Syslog.Api.Providers.CodeGenerator;
using Syslog.Domain.Entities;

namespace Syslog.Api.DeliveryContext.Handlers
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryRequest, CreateDeliveryResponse>
    {
        private readonly ICodeGenerator _codeGenerator;
        private readonly IPublisher _publisher;

        public CreateDeliveryHandler(ICodeGenerator codeGenerator, IPublisher publisher)
        {
            _publisher = publisher;
            _codeGenerator = codeGenerator;
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

            _ = _publisher.Publish(
              new DeliveryCreatedEvent { Address = delivery.Address, Code = delivery.Code },
              cancellationToken);

            return result;
        }
    }
}