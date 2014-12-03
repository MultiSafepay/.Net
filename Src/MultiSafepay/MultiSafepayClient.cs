using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay
{
    public class MultiSafepayClient : IDisposable
    {
        private readonly WebClient _client;
        private readonly UrlProvider _urlProvider;
        private bool _disposed;

        public MultiSafepayClient(string apiKey, string apiApiUrl = "https://pay.multisafepay.com/v1/json/")
        {
            _client = new WebClient();
            _client.Headers["api_key"] = apiKey;

            _urlProvider = new UrlProvider(apiApiUrl);
        }

        #region API Methods

        public Gateway[] GetGateways()
        {
            var response = DoRequest<Gateway[]>(_urlProvider.GatewaysUrl());
            return response.Data;
        }

        public Gateway GetGateway(string gatewayName)
        {
            var response = DoRequest<Gateway>(_urlProvider.GatewayUrl(gatewayName));
            return response.Data;
        }

        public Issuer[] GetIssuers(string gatewayName)
        {
            var response = DoRequest<Issuer[]>(_urlProvider.IssuersUrl(gatewayName));
            return response.Data;
        }

        public OrderResponse GetOrder(string orderId)
        {
            var response = DoRequest<OrderResponse>(_urlProvider.OrderUrl(orderId));
            return response == null ? null : response.Data;
        }

        public Transaction GetTransaction(string transactionId)
        {
            var response = DoRequest<Transaction>(_urlProvider.TransactionUrl(transactionId));
            return response.Data;
        }

        public PaymentLink GetPaymentLink(string orderId)
        {
            var response = DoRequest<PaymentLink>(_urlProvider.PaymentLinkUrl(orderId));
            return response == null ? null : response.Data;
        }

        public PaymentLink CreateOrder(OrderRequest orderRequest)
        {
            var response = DoRequest<PaymentLink>(_urlProvider.OrdersUrl(), orderRequest);
            return response.Data;
        }

        public SimpleResult SetOrderInvoiceId(string orderId, string invoiceId)
        {
            var response = DoRequest<object>(_urlProvider.OrderUrl(orderId),
                new UpdateOrder()
                {
                    InvoiceId = invoiceId
                }, "PATCH");
            return new SimpleResult() {Success = response.Success};
        }

        public RefundResult CreateRefund(string orderId, int refundAmountInCents, string currencyCode, string description)
        {

            var response = DoRequest<RefundResult>(_urlProvider.OrderRefundsUrl(orderId),
            new UpdateOrder()
            {
                Type = "refund",
                Amount = refundAmountInCents,
                Currency = currencyCode,
                Description = description
            });

            return response.Data;
        }

        public SimpleResult UpdateOrderShippedStatus(string orderId, string trackingCode, string carrier, DateTime shippedDate)
        {
            var response = DoRequest<object>(_urlProvider.OrderUrl(orderId),
               new UpdateOrder()
               {
                   TrackingCode = trackingCode,
                   Carrier = carrier,
                   ShippingDate = shippedDate
               }, "PATCH");
            return new SimpleResult() { Success = response.Success };
        }

        #endregion


        #region Private Helpers
        private ResponseMessage<T> DoRequest<T>(string url) where T : class
        {
            try
            {
                Trace.WriteLine(String.Empty);
                Trace.WriteLine("GET - " + url);
                var response = _client.DownloadString(url);
                Trace.WriteLine(response);

                return DeserializeResult<T>(response);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var responseContents = reader.ReadToEnd();
                Trace.WriteLine(responseContents);

                if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        private ResponseMessage<T> DoRequest<T>(string url, object data, string httpMethod) where T : class
        {
            try
            {
                // When serializing the request object ignore default values to reduce message size
                string serializedRequest = JsonConvert.SerializeObject(data,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                Trace.WriteLine(String.Empty);
                Trace.WriteLine(httpMethod + "- " + url);
                Trace.WriteLine(serializedRequest);

                var response = _client.UploadString(url, httpMethod, serializedRequest);
                Trace.WriteLine(response);
                return DeserializeResult<T>(response);
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var response = reader.ReadToEnd();
                Trace.WriteLine(response);

                var r = JsonConvert.DeserializeObject<ResponseMessage>(response);

                throw new MultiSafepayException(r.ErrorCode, r.ErrorInfo, ex);
            }
        }

        private ResponseMessage<T> DoRequest<T>(string url, object data) where T : class
        {
            return DoRequest<T>(url, data, "POST");
        }

        private static ResponseMessage<T> DeserializeResult<T>(string response) where T : class
        {
            var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);
            if (serializedResult.Success == false)
            {
                throw new MultiSafepayException(serializedResult.ErrorCode, serializedResult.ErrorInfo);
            }
            return serializedResult;
        }

        #endregion

        #region Disposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing && _client != null)
            {
                _client.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}
