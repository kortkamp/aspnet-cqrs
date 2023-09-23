using MediatR;

using Syslog.Api.Commands.Requests;
using Syslog.Api.Commands.Responses;
using Syslog.Api.Providers.CodeGenerator;

namespace Syslog.Api.DeliveryContext.Handlers
{
    public class CollectDeliveryHandler
        : IRequestHandler<CollectDeliveryRequest, CollectDeliveryResponse>
    {
        private readonly ICodeGenerator codeGenerator;
        private readonly IPublisher publisher;

        public CollectDeliveryHandler(ICodeGenerator codeGenerator, IPublisher publisher)
        {
            this.publisher = publisher;
            this.codeGenerator = codeGenerator;
        }

        public Task<CollectDeliveryResponse> Handle(
            CollectDeliveryRequest request,
            CancellationToken cancellationToken)
        {
            var result = new CollectDeliveryResponse { Id = Guid.NewGuid() };

            return Task.FromResult(result);
        }
    }
}