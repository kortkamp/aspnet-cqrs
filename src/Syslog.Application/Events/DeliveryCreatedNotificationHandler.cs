using MediatR;

namespace Syslog.Application.Events
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