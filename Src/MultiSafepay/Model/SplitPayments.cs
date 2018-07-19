using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class SplitPayments
    {
        [JsonProperty("merchant")]
        public int merchant { get; set; }
        [JsonProperty("percentage")]
        public float percentage { get; set; }
        [JsonProperty("fixed")]
        public int @fixed { get; set; }
        [JsonProperty("description")]
        public int description { get; set; }
    }
}