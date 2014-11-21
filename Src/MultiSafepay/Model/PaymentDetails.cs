using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }
        [JsonProperty("external_transaction_id")]
        public string ExternalTransactionId { get; set; }
    }
}