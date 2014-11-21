using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderResponse
    {
        [JsonProperty("ewallet")]
        public OrderStatus OrderStatus { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("customer_delivery")]
        public DeliveryAddress DeliveryAddress { get; set; }
        [JsonProperty("transaction")]
        public OrderTransaction TransactionDetails { get; set; }
        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}
