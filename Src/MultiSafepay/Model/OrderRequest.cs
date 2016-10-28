using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class OrderRequest
    {
        private OrderRequest(OrderType type, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            Type = type;
            OrderId = orderId;
            Description = description;
            AmountInCents = amountInCents;
            CurrencyCode = currencyCode;
            PaymentOptions = paymentOptions;
            CustomInfo = new ExpandoObject();
        }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        internal OrderType Type { get; private set; }
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
        [JsonProperty("days_active")]
        public string DaysActive { get; set; }
        [JsonProperty("gateway_info")]
        public GatewayInfo GatewayInfo { get; set; }
        [JsonProperty("payment_options")]
        public PaymentOptions PaymentOptions { get; set; }
        [JsonProperty("customer")]
        public Customer Customer { get; set; }
        [JsonProperty("delivery")]
        public DeliveryAddress DeliveryAddress { get; set; }
        [JsonProperty("shopping_cart")]
        public ShoppingCart ShoppingCart { get; set; }
        [JsonProperty("checkout_options")]
        public CheckoutOptions CheckoutOptions { get; set; }
        [JsonProperty("custom_fields")]
        public CustomField[] CustomFields { get; set; }

        public static OrderRequest CreateDirectIdeal(string issuerId, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId   = "iDEAL",
                GatewayInfo = GatewayInfo.IDeal(issuerId)
            };
        }

        public static OrderRequest CreateDirectIdealQR(int qrSize, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                OrderType.Redirect,//Also supported empty or OrderType.Direct
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId   = "IDEALQR",
                GatewayInfo = GatewayInfo.IDealQR(qrSize)
            };
        }

        public static OrderRequest CreateRedirect(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                OrderType.Redirect,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions);
        }

        public static OrderRequest CreateDirectPayAfterDeliveryOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions, Customer customer)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "PAYAFTER",
                GatewayInfo = gatewayInfo,
                ShoppingCart = shoppingCart,
                Customer = customer,
                CheckoutOptions = checkoutOptions
            };
        }

        [System.Obsolete("use class CreateRedirectPayAfterDeliveryOrder with checkoutOptions")]
        public static OrderRequest CreateRedirectPayAfterDeliveryOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart, Customer customer)
        {
            return CreateRedirectPayAfterDeliveryOrder(orderId, description, amountInCents, currencyCode, paymentOptions, gatewayInfo, shoppingCart, new CheckoutOptions(), customer);
        }

        public static OrderRequest CreateRedirectPayAfterDeliveryOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart,CheckoutOptions checkoutOptions, Customer customer)
        {
            return new OrderRequest(
                OrderType.Redirect,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "PAYAFTER",
                GatewayInfo = gatewayInfo,
                ShoppingCart = shoppingCart,
                Customer = customer,
                CheckoutOptions = checkoutOptions
            };
        }
        
        public static OrderRequest CreateDirectBankTransfer(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "BANKTRANS"
            };
        }

        public static OrderRequest CreateFastCheckoutOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions)
        {
            return new OrderRequest(
                OrderType.FastCheckout,
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
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                RecurringId = recurringId
            };

        }

        public static OrderRequest CreateDirectKlarnaOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions, Customer customer, DeliveryAddress deliveryAddress)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "KLARNA",
                GatewayInfo = gatewayInfo,
                ShoppingCart = shoppingCart,
                Customer = customer,
                DeliveryAddress = deliveryAddress,
                CheckoutOptions = checkoutOptions
            };
        }

        public static OrderRequest CreateDirectEinvoiceOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions, Customer customer, DeliveryAddress deliveryAddress)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "EINVOICE",
                GatewayInfo = gatewayInfo,
                ShoppingCart = shoppingCart,
                Customer = customer,
                DeliveryAddress = deliveryAddress,
                CheckoutOptions = checkoutOptions
            };
        }
    }
}
