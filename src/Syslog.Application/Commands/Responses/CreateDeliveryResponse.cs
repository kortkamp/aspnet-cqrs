namespace Syslog.Application.Commands.Responses
{
    public class CreateDeliveryResponse
    {
        public Guid Id { get; set; }

        public required string Code { get; set; }

        public DateTime CreationDate { get; set; }
    }
}