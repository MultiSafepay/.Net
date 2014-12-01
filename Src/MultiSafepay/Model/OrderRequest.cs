using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MultiSafepay.Model
{
    public class OrderRequest
    {
        public OrderRequest(PaymentFlow paymentFlow, string orderId, int amountInCents, string currency, PaymentOptions paymentOptions)
        {
            PaymentFlow = paymentFlow;
            OrderId = orderId;
            Currency = currency;
            PaymentOptions = paymentOptions;
            AmountInCents = amountInCents;

        }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public PaymentFlow PaymentFlow { get; set; }
        [JsonProperty("id")]
        public string OrderId { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public int AmountInCents { get; set; }
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
        [JsonProperty("payment_options")]
        public PaymentOptions PaymentOptions { get; set; }
    }
}
