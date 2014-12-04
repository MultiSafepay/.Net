using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Transaction
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("status")]
        public string TransactionStatus { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty("order_status")]
        public string OrderStatus { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }
    }
}