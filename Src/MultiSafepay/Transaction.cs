using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay
{
    public class Transaction
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("status")]
        public string TransactionStatus { get; set; }
        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }
    }
}