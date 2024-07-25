namespace Gateway.OnestVision.Models.WhatsApp.Components
{
    public class Template
    {
        public string name { get; set; }
        public Language language { get; set; }
        public List<RequestComponent> components { get; set; }
    }

    public class Language
    {
        public string code { get; set; }
    }

    public class RequestComponent
    {
        public string type { get; set; }
        public List<Parameter> parameters { get; set; }
    }

    public class Parameter
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
