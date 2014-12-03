using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderResponse
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty("id")]
        public string OrderId { get; set; }
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty("amount")]
        public int AmountInCents { get; set; }
        [JsonProperty("gateway")]
        public int GatewayId { get; set; }
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
        [JsonProperty("ewallet")]
        public OrderStatus OrderStatus { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("customer_delivery")]
        public DeliveryAddress DeliveryAddress { get; set; }
        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}
