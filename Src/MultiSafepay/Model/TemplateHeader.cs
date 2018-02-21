using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateHeader
    {
        [JsonProperty("logo")]
        public TemplateHeaderObject Logo { get; set; }
        [JsonProperty("cover")]
        public TemplateHeaderObject Cover { get; set; }
        [JsonProperty("background")]
        public string Background { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
