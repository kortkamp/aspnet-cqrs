using Syslog.Domain.Enums;

namespace Syslog.Domain.Entities
{
    public class DeliveryEvent
    {
        public DeliveryEvent(DeliveryState state)
        {
            Id = Guid.NewGuid();
            State = state;
            Date = DateTime.Now;
        }

        public DeliveryEvent(Guid id, DeliveryState state, DateTime date)
        {
            Id = id;
            State = state;
            Date = date;
        }

        public Guid Id { get; }

        public DeliveryState State { get; }

        public DateTime Date { get; }
    }
}