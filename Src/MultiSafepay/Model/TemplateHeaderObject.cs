using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateHeaderObject
    {
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
