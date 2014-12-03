using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class OrderRequest
    {
        private OrderRequest(PaymentFlow paymentFlow, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            PaymentFlow = paymentFlow;
            OrderId = orderId;
            Description = description;
            AmountInCents = amountInCents;
            CurrencyCode = currencyCode;
            PaymentOptions = paymentOptions;
        }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        internal PaymentFlow PaymentFlow { get; private set; }
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
        [JsonProperty("items")]
        public string Items { get; set; }
        [JsonProperty("manual")]
        public string Manual { get; set; }
        [JsonProperty("days_active")]
        public string DaysActive { get; set; }
        [JsonProperty("gateway_info")]
        public GatewayInfo GatewayInfo { get; set; }
        [JsonProperty("payment_options")]
        public PaymentOptions PaymentOptions { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("shopping_cart")]
        public ShoppingCart ShoppingCart { get; set; }
        [JsonProperty("checkout_options")]
        public CheckoutOptions CheckoutOptions { get; set; }

        public static OrderRequest CreateDirectIdeal(string issuerId, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                PaymentFlow.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "iDEAL",
                GatewayInfo = GatewayInfo.IDeal(issuerId)
            };
        }

        public static OrderRequest CreateRedirect(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                PaymentFlow.Redirect,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions);
        }

        public static OrderRequest CreatePayAfterDeliveryOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, Customer customer)
        {
            return new OrderRequest(
                PaymentFlow.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "PAYAFTER",
                GatewayInfo = gatewayInfo,
                Customer = customer
            };
        }

        public static OrderRequest CreateDirectBankTransfer(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                PaymentFlow.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "BANKTRANST"
            };
        }

        public static OrderRequest CreateFastCheckoutOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions)
        {
            return new OrderRequest(
                PaymentFlow.FastCheckout,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                ShoppingCart = shoppingCart,
                CheckoutOptions = checkoutOptions
            };
        }

        public static OrderRequest CreateRecurring(string recurringId, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                PaymentFlow.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                RecurringId = recurringId
            };

        }
    }
}
