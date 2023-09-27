namespace Syslog.Domain.Enums
{
    public enum DeliveryState
    {
        Awaiting,
        InRoute,
        Delivered,
        Cancelled,
        ReturnedToSender,
    }
}