using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Template
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("settings")]
        public TemplateSettings Settings { get; set; }
        [JsonProperty("header")]
        public TemplateHeader Header { get; set; }
        [JsonProperty("body")]
        public TemplateBody Body { get; set; }
        [JsonProperty("container")]
        public TemplateContainer Container { get; set; }
        [JsonProperty("cart")]
        public TemplateCart Cart { get; set; }
        [JsonProperty("payment_form")]
        public TemplatePaymentForm PaymentForm { get; set; }
        [JsonProperty("buttons")]
        public TemplateButtons Buttons { get; set; }
    }
}