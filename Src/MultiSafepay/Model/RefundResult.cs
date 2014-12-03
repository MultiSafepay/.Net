using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class RefundResult
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; } 
    }
}