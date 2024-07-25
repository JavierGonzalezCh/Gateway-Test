namespace Gateway.OnestVision.Models.WhatsApp.ServiceModels
{
    public class SendMessageServiceModel
    {
        public string Bussiness { set; get; }
        public string Message { set; get; }
        public List<string> PhoneNumbers { set; get; }
    }
}
