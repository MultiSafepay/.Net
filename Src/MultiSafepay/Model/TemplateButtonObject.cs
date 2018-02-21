using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateButtonObject
    {
        [JsonProperty("background")]
        public string Background { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("border")]
        public string Border { get; set; }
        [JsonProperty("hover")]
        public TemplateButtonObjectState Hover { get; set; }
        [JsonProperty("active")]
        public TemplateButtonObjectState Active { get; set; }
    }
}
