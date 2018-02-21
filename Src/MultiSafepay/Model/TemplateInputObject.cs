using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateInputObject
    {
        [JsonProperty("border")]
        public string Border { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
