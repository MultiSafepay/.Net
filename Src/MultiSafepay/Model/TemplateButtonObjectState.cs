using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateButtonObjectState
    {
        [JsonProperty("background")]
        public string Background { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("boder")]
        public string Border { get; set; }
    }
}
