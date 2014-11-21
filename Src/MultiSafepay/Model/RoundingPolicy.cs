using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class RoundingPolicy
    {
        [JsonProperty("mode"), JsonConverter(typeof(StringEnumConverter))]
        public RoundingMode RoundingMode { get; set; }
        [JsonProperty("rule"), JsonConverter(typeof(StringEnumConverter))]
        public RoundingRule RoundingRule { get; set; }
    }
}