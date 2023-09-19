namespace Syslog.Api.Commands.Responses
{
    public class CreateDeliveryResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }
    }
}