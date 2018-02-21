using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateCart
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("background")]
        public string Background { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("border")]
        public string Border { get; set; }
    }
}
