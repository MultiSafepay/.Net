using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class SplitPayments
    {
        [JsonProperty("merchant")]
        public int merchant { get; set; }
        [JsonProperty("percentage", NullValueHandling = NullValueHandling.Ignore)]
        public float? percentage { get; set; }
        [JsonProperty("fixed")]
        public int? @fixed { get; set; }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
    }
}