namespace Gateway.OnestVision.Models.WhatsApp.Components
{
    public class CreateTemplateComponents
    {
        public string type { get; set; }
        public string text { get; set; }
        public List<ButtonComponent> buttons { get; set; }
        public ExampleParameter example { get; set; }
    }
    public class ExampleParameter
    {
        public List<string> body_text { get; set; }
    }
    public class ButtonComponent
    {
        public string type { get; set; } = "QUICK_REPLY";
        public string text { get; set; }
    }
}
