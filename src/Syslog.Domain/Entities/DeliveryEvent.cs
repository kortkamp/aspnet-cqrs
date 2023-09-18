using CqrsPoc.Domain.Enums;

namespace CqrsPoc.Domain.Entities
{
    public readonly struct DeliveryEvent
    {
        public Guid Id { get; }
        public DeliveryState State {get; }
        public DateTime Date { get; }

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
    }
}