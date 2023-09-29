namespace Syslog.Api.Commands.Responses
{
    public class FinishDeliveryResponse
    {
        public Guid Id { get; set; }

        public string Receiver { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}