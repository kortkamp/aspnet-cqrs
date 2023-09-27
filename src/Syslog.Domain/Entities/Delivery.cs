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

        public DeliveryState State { get; private set; }

        public IList<DeliveryEvent> Events { get; private set; }

        public DateTime CreationDate { get; private set; }

        public Guid? DeliverymanId { get; private set; }

        // sender data
        public string Code { get; private set; }

        public string OrderId { get; private set; }

        // destination data
        public string Address { get; private set; }

        public DateTime? DeliveredAt { get; private set; }

        public string? DeliveredTo { get; private set; }

        public DeliveryEvent Collect(Guid deliveryManId)
        {
            if (State != DeliveryState.Awaiting)
            {
                throw new InvalidOperationException(
                    "The delivery must be Awaiting to be collected");
            }

            DeliverymanId = deliveryManId;
            return UpdateState(DeliveryState.InRoute);
        }

        public DeliveryEvent Finish(string receiver)
        {
            if (State != DeliveryState.InRoute)
            {
                throw new InvalidOperationException(
                    "The delivery must be in route to be delivered");
            }

            DeliveredAt = DateTime.Now;
            DeliveredTo = receiver;
            return UpdateState(DeliveryState.Delivered);
        }

        public DeliveryEvent Cancel()
        {
            return UpdateState(DeliveryState.Cancelled);
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

        private DeliveryEvent UpdateState(DeliveryState state)
        {
            var deliveryEvent = new DeliveryEvent(state);
            Events.Add(deliveryEvent);
            State = DeliveryState.InRoute;
            return deliveryEvent;
        }
    }
}