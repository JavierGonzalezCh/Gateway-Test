using Gateway.OnestVision.Models.WhatsApp.ServiceModels;

namespace Gateway.OnestVision.Services.Interfaces.WhatsApp
{
    public interface IWhatsAppService
    {
        public Task<string> SendMessage(SendMessageServiceModel message);
        public Task<string> SendTemplate(SendTemplateServiceModel message);
        public Task<string> CreateTemplate(CreateTemplateServiceModel templateData);
    }
}
