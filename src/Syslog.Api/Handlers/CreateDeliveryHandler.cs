using MediatR;
using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Api.Providers.CodeGenerator;
using Syslog.Domain.Entities;

namespace Syslog.Api.DeliveryContext.Handlers
{
    public class CreateDeliveryHandler : IRequestHandler<CreateDeliveryRequest, CreateDeliveryResponse>
    {
        readonly ICodeGenerator _codeGenerator;
        public CreateDeliveryHandler(ICodeGenerator codeGenerator)
        {
            _codeGenerator = codeGenerator;
        }

        public async Task<CreateDeliveryResponse> Handle(CreateDeliveryRequest command, CancellationToken cancellationToken)
        {
            var code = await _codeGenerator.Generate();
            var delivery = new Delivery(code, command.OrderId, command.Address);

            var result =  new CreateDeliveryResponse{
                Id = delivery.Id,
                Code = delivery.Code,
                CreationDate = delivery.CreationDate
            };

            return result;
        }
    }
}