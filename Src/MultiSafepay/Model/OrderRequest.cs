using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderRequest
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("var1")]
        public string Var1 { get; set; }
        [JsonProperty("var2")]
        public string Var2 { get; set; }
        [JsonProperty("var3")]
        public string Var3 { get; set; }
        [JsonProperty("items")]
        public string Items { get; set; }
        [JsonProperty("manual")]
        public string Manual { get; set; }
        [JsonProperty("days_active")]
        public string DaysActive { get; set; }
    }
}
