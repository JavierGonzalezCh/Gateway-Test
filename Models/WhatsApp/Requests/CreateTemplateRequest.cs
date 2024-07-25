using Gateway.OnestVision.Models.WhatsApp.Components;

namespace Gateway.OnestVision.Models.WhatsApp.Requests
{
    public class CreateTemplateRequest
    {
        public bool allow_category_change { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public string category { get; set; }
        public List<CreateTemplateComponents> components { get; set; }
    }
}
