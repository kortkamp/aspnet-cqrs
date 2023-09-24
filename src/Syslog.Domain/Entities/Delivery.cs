using Syslog.Domain.Enums;

namespace Syslog.Domain.Entities
{
    public class Delivery
    {
        public Delivery(
            string code,
            string orderId,
            string address)
        {
            Id = Guid.NewGuid();
            Code = code;
            State = DeliveryState.Awaiting;
            Events = new List<DeliveryEvent>();
            OrderId = orderId;
            Address = address;
            CreationDate = DateTime.Now;
        }

        public Delivery(
            Guid id,
            string code,
            IList<DeliveryEvent> events,
            DeliveryState state,
            DateTime creationDate,
            DateTime deliveredAt,
            Guid deliverymanId,
            string orderId,
            string address)
        {
            Id = id;
            Code = code;
            Events = events;
            State = state;
            CreationDate = creationDate;
            DeliveredAt = deliveredAt;
            DeliverymanId = deliverymanId;
            OrderId = orderId;
            Address = address;
        }

        public Guid Id { get; private set; }

        public string Code { get; private set; }

        public DateTime CreationDate { get; private set; }

        public string OrderId { get; private set; }

        public string Address { get; private set; }

        public DeliveryState State { get; private set; }

        public IList<DeliveryEvent> Events { get; private set; }

        public Guid? DeliverymanId { get; private set; }

        public DateTime? DeliveredAt { get; private set; }

        public string? DeliveredTo { get; private set; }

        public bool Collect(Guid deliveryManId)
        {
            if (State != DeliveryState.Awaiting)
            {
                throw new InvalidOperationException(
                    "The delivery must be Awaiting to be collected");
            }

            DeliverymanId = deliveryManId;
            UpdateState(DeliveryState.InRoute);
            return true;
        }

        public bool Finish(string receiver)
        {
            if (State != DeliveryState.InRoute)
            {
                throw new InvalidOperationException(
                    "The delivery must be in route to be delivered");
            }

            DeliveredAt = DateTime.Now;
            DeliveredTo = receiver;
            UpdateState(DeliveryState.Delivered);

            return true;
        }

        public bool Cancel()
        {
            UpdateState(DeliveryState.Cancelled);

            return true;
        }

        public bool UpdateAddress(string address)
        {
            if (State == DeliveryState.Delivered)
            {
                throw new InvalidOperationException("The delivery is already finished");
            }

            Address = address;
            return true;
        }

        private void UpdateState(DeliveryState state)
        {
            Events.Add(new DeliveryEvent(state));
            State = DeliveryState.InRoute;
        }
    }
}