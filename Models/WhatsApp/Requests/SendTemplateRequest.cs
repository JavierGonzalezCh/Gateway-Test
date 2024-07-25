using Gateway.OnestVision.Models.WhatsApp.Components;

namespace Gateway.OnestVision.Models.WhatsApp.Requests
{
    public class SendTemplateRequest
    {
        public string messaging_product { get; set; }
        public string to { get; set; }
        public string type { get; set; }
        public Template template { get; set; }
    }

}
