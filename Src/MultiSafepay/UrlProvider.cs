using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace MultiSafepay
{
    /// <summary>
    /// Generates urls for the different operations available on the MultiSafepay API
    /// </summary>
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

        public string GatewaysUrl(string countryCode = null, string currency = null, int? amount = null)
        {
            var builder = new Uri(_baseUrl + "gateways");
            var queryStringComponents = new Dictionary<string, string>()
            {
                {"country", HttpUtility.UrlEncode(countryCode)},
                {"currency", currency},
                {"amount", amount.HasValue ? amount.ToString() : null}
            }
                .Where(x => !String.IsNullOrEmpty(x.Value));

            var queryString = String.Join("&", queryStringComponents.Select(x => String.Format("{0}={1}", x.Key, x.Value)));


            if (!String.IsNullOrEmpty(queryString))
            {
                return _baseUrl + "gateways?" + queryString;
            }

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

        public string OrderRefundsUrl(string orderId)
        {
            return _baseUrl + "orders/" + orderId + "/refunds";
        }
    }
}
