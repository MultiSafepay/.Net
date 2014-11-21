using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class FieldDescription
    {
        [JsonProperty("value")]
        public string LabelText { get; set; }
        [JsonProperty("style")]
        public string CssStyle { get; set; }

    }
}