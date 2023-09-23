using MediatR;

namespace Syslog.Api.Events
{
    public class DeliveryCreatedNotificationHandler : INotificationHandler<DeliveryCreatedEvent>
    {
        public Task Handle(DeliveryCreatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Delivery Created with number {notification.Code:S}");
            return Task.CompletedTask;
        }
    }
}