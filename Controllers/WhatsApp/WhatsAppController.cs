using Gateway.OnestVision.Models.WhatsApp.ServiceModels;
using Gateway.OnestVision.Services.Interfaces.WhatsApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsApp_Aplication.Services;

namespace WhatsApp_Aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private readonly IWhatsAppService _whatsAppService;

        public WhatsAppController(IWhatsAppService serviceMarketMix)
        {
            _whatsAppService = serviceMarketMix;
        }

        [HttpPost("SendMessage")]
        public async Task<string> SendMessage([FromBody] SendMessageServiceModel user)
        {
            return await _whatsAppService.SendMessage(user);
        }
        [HttpPost("SendTemplate")]
        public async Task<string> SendTemplate([FromBody] SendTemplateServiceModel user)
        {
            return await _whatsAppService.SendTemplate(user);
        }
        [HttpPost("CreateTemplate")]
        public async Task<string> CreateTemplate([FromBody] CreateTemplateServiceModel user)
        {
            return await _whatsAppService.CreateTemplate(user);
        }
    } 
}
