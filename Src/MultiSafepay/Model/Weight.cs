using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Weight
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("value")]
        public dynamic Value { get; set; }
    }
}