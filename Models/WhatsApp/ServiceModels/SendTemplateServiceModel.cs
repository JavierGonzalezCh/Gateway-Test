namespace Gateway.OnestVision.Models.WhatsApp.ServiceModels
{
    public class SendTemplateServiceModel
    {
        public string Bussiness { set; get; }
        public string TemplateName { set; get; }
        public string PersonPhone { set; get; }
        public List<string> Parameters { set; get; }
    }
}
