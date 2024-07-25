namespace Gateway.OnestVision.Models.WhatsApp.ServiceModels
{
    public class SendTemplateServiceModel
    {
        public string Bussiness { set; get; }
        public string TemplateName { set; get; }
        public List<User> Users { set; get; }
        
    }
    public class User 
    {
        public string PersonPhone { set; get; }
        public List<string> Parameters { set; get; }
    }

}
