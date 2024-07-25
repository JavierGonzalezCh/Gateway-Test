using Gateway.OnestVision.Models.WhatsApp.Components;

namespace Gateway.OnestVision.Models.WhatsApp.ServiceModels
{
    public class CreateTemplateServiceModel
    {
        public string Bussiness { set; get; }
        public string TemplateName { set; get; }
        public string Body { set; get; }
        public List<string> BodyExamples { set; get; }
        public List<ButtonComponent> Buttons { set; get; }  
    }
}
