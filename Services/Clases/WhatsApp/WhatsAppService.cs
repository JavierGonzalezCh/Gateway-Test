using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;
using Gateway.OnestVision.Services.Interfaces.WhatsApp;
using Gateway.OnestVision.Models.WhatsApp;
using Microsoft.Extensions.Options;
using Gateway.OnestVision.Models.WhatsApp.ServiceModels;
using Gateway.OnestVision.Models.WhatsApp.Components;
using Gateway.OnestVision.Models.WhatsApp.Requests;
using System.Text.RegularExpressions;

namespace WhatsApp_Aplication.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppSettings _whatsAppSettings;

        public WhatsAppService(HttpClient httpClient,  IOptions<WhatsAppSettings> whatsAppSettings)
        {
            _httpClient = httpClient;
            _whatsAppSettings = whatsAppSettings.Value;
        }
        private BusinessSettings GetBusinessSettings(string businessName)
        {
            if (_whatsAppSettings.Bussiness.TryGetValue(businessName, out var businessSettings))
            {
                return businessSettings;
            }
            throw new Exception("Bussiness not found");
        }
        private int GetTotalPlaceholders(string stringWithPlaceholders)
        {
            var matches = Regex.Matches(stringWithPlaceholders, @"{{\d+}}");
            return matches.Count;
        }
        public async Task<string> SendMessage(SendMessageServiceModel message)
        {
            string result;
            try
            {
                BusinessSettings businessSettings = GetBusinessSettings(message.Bussiness);

                var messageModel = new SendMessageRequest
                {
                    messaging_product = "whatsapp",
                    recipient_type = "individual",
                    to = message.PersonPhone,
                    type = "text",
                    text = new TextMessage
                    {
                        preview_url = false,
                        body = message.Message
                    }
                };

                var json = JsonSerializer.Serialize(messageModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _whatsAppSettings.Token);

                var url = $"{_whatsAppSettings.ApiUrl}/{businessSettings.PhoneId}/messages";

                var response = await _httpClient.PostAsync(url, content);

                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        public async Task<string> SendTemplate(SendTemplateServiceModel message)
        {
            string result;
            try
            {
                BusinessSettings businessSettings = GetBusinessSettings(message.Bussiness);
                List<Parameter> parameters = new List<Parameter>();

                foreach (string parameter in message.Parameters)
                {
                    Parameter param = new Parameter
                    {
                        type = "text",
                        text = parameter
                    };
                    parameters.Add(param);
                }

                var messageModel = new SendTemplateRequest
                {
                    messaging_product = "whatsapp",
                    to = message.PersonPhone,
                    type = "template",
                    template = new Template
                    {
                        name = message.TemplateName,
                        language = new Language
                        {
                            code = "es",
                        },
                        components = new List<RequestComponent>
                        {
                            new RequestComponent
                            {
                                type = "body",
                                parameters = parameters
                            }
                        }
                    }
                };

                var json = JsonSerializer.Serialize(messageModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _whatsAppSettings.Token);

                var url = $"{_whatsAppSettings.ApiUrl}/{businessSettings.PhoneId}/messages";

                var response = await _httpClient.PostAsync(url, content);
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public async Task<string> CreateTemplate(CreateTemplateServiceModel templateData)
        {
            string result;
            try
            {
                BusinessSettings businessSettings = GetBusinessSettings(templateData.Bussiness);
                int totalPlaceHoldersInBody = GetTotalPlaceholders(templateData.Body);

                if (totalPlaceHoldersInBody > 0)
                {
                    if (templateData.BodyExamples.Count != totalPlaceHoldersInBody)
                    {
                        result = "La cantidad de placeholders y ejemplos deben ser iguales";
                        return result;
                    }
                }
                List<CreateTemplateComponents> components = new List<CreateTemplateComponents>();

                CreateTemplateComponents body = new CreateTemplateComponents()
                {
                    type = "BODY",
                    text = templateData.Body,
                };
                if (totalPlaceHoldersInBody > 0)
                {
                    body.example = new ExampleParameter
                    {
                        body_text = templateData.BodyExamples
                    };
                }
                components.Add(body);

                if (templateData.Buttons.Count > 0)
                {
                    CreateTemplateComponents buttons = new CreateTemplateComponents
                    {
                        type = "BUTTONS",
                        buttons = templateData.Buttons
                    };
                    components.Add(buttons);
                }

                var template = new CreateTemplateRequest
                {
                    allow_category_change = true,
                    name = templateData.TemplateName,
                    language = "es",
                    category = "MARKETING",
                    components = components
                };

                var json = JsonSerializer.Serialize(template);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _whatsAppSettings.Token);

                var url = $"{_whatsAppSettings.ApiUrl}/{businessSettings.WhatsAppAccountId}/message_templates";

                var response = await _httpClient.PostAsync(url, content);
                result = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

    }
}
