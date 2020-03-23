using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay.Model
{
    public class OrderRequest : Order
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

        public static OrderRequest createDirect(string issuerId, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
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

        public static OrderRequest CreateDirectIdealQR(GatewayInfo GatewayInfo, string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions)
        {
            return new OrderRequest(
                OrderType.Redirect,//Also supported empty or OrderType.Direct
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "IDEALQR",
                GatewayInfo = GatewayInfo.IDealQR(
                    GatewayInfo.QrSize, 
                    GatewayInfo.MaxAmount, 
                    GatewayInfo.AllowMultiple, 
                    GatewayInfo.AllowChangeAmount)
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

        public static OrderRequest CreateRedirectWithTemplate(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, string TemplateId, Template Template)
        {
            return new OrderRequest(
                OrderType.Redirect,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                TemplateId = TemplateId,
                Template = Template
            };
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

        public static OrderRequest CreateDirectAfterPayOrder(string orderId, string description, int amountInCents, string currencyCode, PaymentOptions paymentOptions, GatewayInfo gatewayInfo, ShoppingCart shoppingCart, CheckoutOptions checkoutOptions, Customer customer, DeliveryAddress deliveryAddress)
        {
            return new OrderRequest(
                OrderType.Direct,
                orderId,
                description,
                amountInCents,
                currencyCode,
                paymentOptions)
            {
                GatewayId = "AFTERPAY",
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