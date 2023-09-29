using MediatR;

namespace Syslog.Application.Events
{
    public class DeliveryCreatedEvent : INotification
    {
        public string? Code { get; init; }

        public string? Address { get; init; }
    }
}