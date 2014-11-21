using System.Net;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay
{
    public class MultiSafepayClient
    {
        private readonly WebClient _client;
        private readonly UrlProvider _urlProvider;

        public MultiSafepayClient(string apiKey, string apiApiUrl = "https://pay.multisafepay.com/v1/json/")
        {
            _client = new WebClient();
            _client.Headers["api_key"] = apiKey;

            _urlProvider = new UrlProvider(apiApiUrl);
        }

        public Gateway[] GetGateways()
        {
            var response = _client.DownloadString(_urlProvider.GatewaysUrl());

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<Gateway[]>>(response);

            return serializedResult.Data;
        }

        public Gateway GetGateway(string gatewayName)
        {
            var response = _client.DownloadString(_urlProvider.GatewayUrl(gatewayName));

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<Gateway>>(response);

            return serializedResult.Data;
        }

        public Issuer[] GetIssuers(string gatewayName)
        {
            var response = _client.DownloadString(_urlProvider.IssuersUrl(gatewayName));

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<Issuer[]>>(response);

            return serializedResult.Data;
        }

        public OrderResponse GetOrder(string orderId)
        {
            var response = _client.DownloadString(_urlProvider.OrderUrl(orderId));

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<OrderResponse>>(response);

            return serializedResult.Data;
        }

        public Transaction GetTransaction(string transactionId)
        {
            var response = _client.DownloadString(_urlProvider.TransactionUrl(transactionId));

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<Transaction>>(response);

            return serializedResult.Data;
        }

        public object GetPaymentLink(string orderId)
        {
            var response = _client.DownloadString(_urlProvider.PaymentLinkUrl(orderId));

            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<Transaction>>(response);

            return serializedResult.Data;
        }
    }
}
