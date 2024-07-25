namespace Gateway.OnestVision.Models.WhatsApp
{
    public class WhatsAppSettings
    {
        public string ApiUrl { get; set; }
        public string Token { get; set; }
        public Dictionary<string, BusinessSettings> Bussiness { get; set; }
    }

    public class BusinessSettings
    {
        public string AppId { get; set; }
        public string PhoneId { get; set; }
        public string WhatsAppAccountId { get; set; }
    }
}
