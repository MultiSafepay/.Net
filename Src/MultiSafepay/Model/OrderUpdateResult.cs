using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderUpdateResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}