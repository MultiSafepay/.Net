using System;

namespace MultiSafepay
{
    internal class UrlProvider
    {
        private readonly string _baseUrl;

        internal UrlProvider(string baseUrl)
        {
            if (!baseUrl.EndsWith("/"))
            {
                _baseUrl = baseUrl + "/";
            }
            else
            {
                _baseUrl = baseUrl;
            }
        }

        public string GatewaysUrl()
        {
            return _baseUrl + "gateways";
        }

        public string GatewayUrl(string gatewayName)
        {
            return _baseUrl + "gateways/" + gatewayName;
        }

        public string IssuersUrl(string gatewayName)
        {
            return _baseUrl + "issuers/" + gatewayName;
        }

        public string OrderUrl(string orderId)
        {
            return _baseUrl + "orders/" + orderId;
        }

        public string TransactionUrl(string transactionId)
        {
            return _baseUrl + "transactions/" + transactionId;
        }

        public string PaymentLinkUrl(string orderId)
        {
            return _baseUrl + "orders/" + orderId + "/paymentlink";
        }

        public string OrdersUrl()
        {
            return _baseUrl + "orders";
        }
    }
}
