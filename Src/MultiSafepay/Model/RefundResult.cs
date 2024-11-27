using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class RefundResult
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("refund_id")]
        public string RefundId { get; set; }

        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}