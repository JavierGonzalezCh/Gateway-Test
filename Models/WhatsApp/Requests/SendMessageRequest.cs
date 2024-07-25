using Gateway.OnestVision.Models.WhatsApp.Components;

namespace Gateway.OnestVision.Models.WhatsApp.Requests
{
    public class SendMessageRequest
    {
        public string messaging_product { get; set; }
        public string recipient_type { get; set; }
        public string to { get; set; }
        public string type { get; set; }
        public TextMessage text { get; set; }
    }

    public class TextMessage
    {
        public bool preview_url { get; set; }
        public string body { get; set; }
    }
}
