using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateButtons
    {
        [JsonProperty("payment_method")]
        public TemplateButtonObject PaymentMethod { get; set; }
        [JsonProperty("primary")]
        public TemplateButtonObject Primary { get; set; }
        [JsonProperty("secondary")]
        public TemplateButtonObject Secondary { get; set; }
    }
}
