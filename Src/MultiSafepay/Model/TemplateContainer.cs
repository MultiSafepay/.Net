using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateContainer
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("background")]
        public string Background { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("link")]
        public TemplateButtonObject Link { get; set; }
    }
}
