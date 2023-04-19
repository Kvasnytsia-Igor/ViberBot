namespace Application.Models
{
    public class ViberEvent
    {
        public string Event { get; set; } = "";
        public string Timestamp { get; set; } = "";
        public string MessageToken { get; set; } = "";
        public ViberSender Sender { get; set; } = new ViberSender();
        public ViberMessage Message { get; set; } = new ViberMessage();
    }
}
