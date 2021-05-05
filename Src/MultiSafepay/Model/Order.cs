using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class Order
    {
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public OrderType Type { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("recurring_id")]
        public string RecurringId { get; set; }
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty("amount")]
        public int AmountInCents { get; set; }
        [JsonProperty("gateway")]
        public string GatewayId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("var1")]
        public string Var1 { get; set; }
        [JsonProperty("var2")]
        public string Var2 { get; set; }
        [JsonProperty("var3")]
        public string Var3 { get; set; }
        [JsonProperty("custom_info")]
        public dynamic CustomInfo { get; set; }
        [JsonProperty("items")]
        public string Items { get; set; }
        [JsonProperty("manual")]
        public string Manual { get; set; }
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
        [JsonProperty("template")]
        public Template Template { get; set; }
        [JsonProperty("days_active")]
        public string DaysActive { get; set; } //@TODO - Set as int in future mayor version upgrade
        [JsonProperty("seconds_active")]
        public int SecondsActive { get; set; }
        [JsonProperty("payment_options")]
        public PaymentOptions PaymentOptions { get; set; }
        [JsonProperty("second_chance")]
        public SecondChance SecondChance { get; set; }
        [JsonProperty("plugin")]
        public Plugin Plugin { get; set; }
        [JsonProperty("gateway_info")]
        public GatewayInfo GatewayInfo { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("delivery")]
        public DeliveryAddress DeliveryAddress { get; set; }
        [JsonProperty("affiliate")]
        public Affiliate Affiliate { get; set; }
        [JsonProperty("shopping_cart")]
        public ShoppingCart ShoppingCart { get; set; }
        [JsonProperty("checkout_options")]
        public CheckoutOptions CheckoutOptions { get; set; }
        [JsonProperty("google_analytics")]
        public GoogleAnalytics GoogleAnalytics { get; set; }
        [JsonProperty("custom_fields")]
        public CustomField[] CustomFields { get; set; }
    }
}