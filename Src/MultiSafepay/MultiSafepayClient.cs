using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay
{
    public class MultiSafepayClient : IDisposable
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
            return DoRequest<Gateway[]>(_urlProvider.GatewaysUrl());
        }

        public Gateway GetGateway(string gatewayName)
        {
            return DoRequest<Gateway>(_urlProvider.GatewayUrl(gatewayName));
        }

        public Issuer[] GetIssuers(string gatewayName)
        {
            return DoRequest<Issuer[]>(_urlProvider.IssuersUrl(gatewayName));
        }

        public OrderResponse GetOrder(string orderId)
        {
            return DoRequest<OrderResponse>(_urlProvider.OrderUrl(orderId));
        }

        public Transaction GetTransaction(string transactionId)
        {
            return DoRequest<Transaction>(_urlProvider.TransactionUrl(transactionId));
        }

        public object GetPaymentLink(string orderId)
        {
            return DoRequest<object>(_urlProvider.PaymentLinkUrl(orderId));
        }

        public object CreateOrder(OrderRequest orderRequest)
        {
            return DoRequest<object>(_urlProvider.OrdersUrl(), orderRequest);
        }


        private T DoRequest<T>(string url)
        {
            var response = _client.DownloadString(url);
            
            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);

            return serializedResult.Data;
        }

        private T DoRequest<T>(string url, object postData)
        {
            try
            {
                var response = _client.UploadString(url, JsonConvert.SerializeObject(postData));

                var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);

                return serializedResult.Data;
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var response = reader.ReadToEnd();

                var r = JsonConvert.DeserializeObject<ResponseMessage>(response);

                throw new MultiSafepayException(r.ErrorCode, r.ErrorInfo, ex);
            }
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }
    }
}
