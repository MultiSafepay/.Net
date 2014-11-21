using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Refund
    {
        [JsonProperty("type")]
        public string TransactionType = "refund";
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
