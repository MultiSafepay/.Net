using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using MultiSafepay.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MultiSafepay
{
    /// <summary>
    /// WebClient wrapper that encapsulates the logic required to submit an OrderRequest to 
    /// the MultiSafepay API. Contains methods for each available call on the API.
    /// </summary>
    public class MultiSafepayClient : IDisposable
    {
        private readonly WebClient _client;
        private readonly UrlProvider _urlProvider;
        private bool _disposed;
        public string Language { get; set; }

        public MultiSafepayClient(string apiKey, string apiUrl = "https://api.multisafepay.com/v1/json/", string languageCode = null)
        {
            _client = new WebClient();
            _client.Headers["api_key"] = apiKey;
            _client.Headers[HttpRequestHeader.ContentType] = "application/json";
            _client.Encoding = System.Text.Encoding.UTF8;
            
            _urlProvider = new UrlProvider(apiUrl, languageCode);
        }



        #region API Methods

        /// <summary>
        /// Gets a list of all payment methods configured for the users account
        /// </summary>
        public Gateway[] GetGateways(string countryCode = null, string currency = null, int? amount = null)
        {
            var response = DoRequest<Gateway[]>(_urlProvider.GatewaysUrl(countryCode, currency, amount));
            return response.Data;
        }

        /// <summary>
        /// Gets data for a specific payment method
        /// </summary>
        /// <param name="gatewayId">The unique identifier for the payment method</param>
        public Gateway GetGateway(string gatewayId)
        {
            var response = DoRequest<Gateway>(_urlProvider.GatewayUrl(gatewayId));
            return response.Data;
        }

        /// <summary>
        /// Gets all available issuers which are available to process a particular payment method
        /// </summary>
        /// <param name="gatewayId">The unique identifier for the payment method</param>
        public Issuer[] GetIssuers(string gatewayId)
        {
            var response = DoRequest<Issuer[]>(_urlProvider.IssuersUrl(gatewayId));
            return response.Data;
        }

        /// <summary>
        /// Retrieves details about a particular order
        /// </summary>
        /// <param name="orderId">The client specified order id</param>
        public OrderResponse GetOrder(string orderId)
        {
            var response = DoRequest<OrderResponse>(_urlProvider.OrderUrl(orderId));
            return response == null ? null : response.Data;
        }

        /// <summary>
        /// Create a simple redirect order
        /// </summary>
        /// <param name="orderRequest">OrderRequest object populated with the order details</param>
        /// <returns>The payment link to redirect the customer too</returns>
        public PaymentLink CreateOrder(OrderRequest orderRequest)
        {
            var response = DoRequest<PaymentLink>(_urlProvider.OrdersUrl(), orderRequest);
            return response.Data;
        }

        /// <summary>
        /// Updates an existing order with a specific invoice id. 
        /// Used when invoices are created after payment.
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// <param name="invoiceNumber">The invoice number to store</param>
        /// <returns>Whether or not the operation succeeded</returns>
        public SimpleResult SetOrderInvoiceNumber(string orderId, string invoiceNumber)
        {
            var response = DoRequest<object>(_urlProvider.OrderUrl(orderId),
                new UpdateOrder()
                {
                    InvoiceId = invoiceNumber
                }, "PATCH");
            return new SimpleResult() { Success = response.Success };
        }

        /// <summary>
        /// Issues a refund for a particular order
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// <param name="refundAmountInCents">The amount to refund</param>
        /// <param name="currencyCode">The currency to issue the refund in</param>
        /// <param name="description">A description for the refund transaction</param>
        /// <returns>The MultiSafepay unique identifier for the refund transaction</returns>
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

        /// <summary>
        /// Update a Pay After Delivery order status to shipped.
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// <param name="trackingCode">The tracking code for the parcel</param>
        /// <param name="carrier">The shipping company</param>
        /// <param name="shippedDate">The date the parcel was shipped</param>
        public SimpleResult UpdateOrderShippedStatus(string orderId, string trackingCode, string carrier, DateTime shippedDate, string memo = null)
        {
            var response = DoRequest<object>(_urlProvider.OrderUrl(orderId),
               new UpdateOrder()
               {
                   TrackingCode = trackingCode,
                   Carrier = carrier,
                   ShippingDate = shippedDate,
                   Memo = memo
               }, "PATCH");
            return new SimpleResult() { Success = response.Success };
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Performs a GET operation on a particular resource
        /// </summary>
        /// <typeparam name="T">The type of the response message to deserialize into</typeparam>
        /// <param name="url">The url of the resource to request</param>
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
                // Issues with the MultiSafepay API result in WebExceptions due to the HTTP status
                // codes being returned. More information is available in the JSON formatted
                // content of the response.
                var response = ex.Response as HttpWebResponse;
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var responseContents = reader.ReadToEnd();
                Trace.WriteLine(responseContents);

                // If a resource was not found and resulted in a 404 return null
                if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Sends data to the MultiSafepay API.
        /// </summary>
        /// <typeparam name="T">The type of the response message to deserialize into</typeparam>
        /// <param name="url">The url to submit the request to</param>
        /// <param name="data">The data object to serialized and submit</param>
        /// <param name="httpMethod">The HTTP METHOD to use when sending the request</param>
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
                //Response from server is not empty
                if (ex.Response != null)
                {
                    var reader = new StreamReader(ex.Response.GetResponseStream());
                    var response = reader.ReadToEnd();
                    Trace.WriteLine(response);

                    var r = JsonConvert.DeserializeObject<ResponseMessage>(response);

                    throw new MultiSafepayException(r.ErrorCode, r.ErrorInfo, ex);
                }
                //No response from server, possible 404 or timeout
                throw new MultiSafepayException(9999,
                    String.Format("{0}{1}{1}{2}",
                    "Error deserializing response. Possible error on server.",
                    Environment.NewLine,
                    url),
                    ex);
            }
        }

        /// <summary>
        /// POSTs data to the MultiSafepay API.
        /// </summary>
        /// <typeparam name="T">The type of the response message to deserialize into</typeparam>
        /// <param name="url">The url to submit the request to</param>
        /// <param name="data">The data object to serialized and submit</param>
        private ResponseMessage<T> DoRequest<T>(string url, object data) where T : class
        {
            return DoRequest<T>(url, data, "POST");
        }

        /// <summary>
        /// Create a strongly typed object from a JSON response from the MultiSafepay API
        /// </summary>
        /// <typeparam name="T">The strongly typed object to create</typeparam>
        /// <param name="response">The raw JSON response message</param>
        /// <returns></returns>
        private static ResponseMessage<T> DeserializeResult<T>(string response) where T : class
        {
            try
            {
                var format = "dd-MM-yyyy HH:mm:ss"; // MSP api standard date time format
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                var serializedResult = JsonConvert.DeserializeObject<ResponseMessage<T>>(response, dateTimeConverter);
                if (serializedResult.Success == false)
                {
                    throw new MultiSafepayException(serializedResult.ErrorCode, serializedResult.ErrorInfo);
                }
                return serializedResult;
            }
            catch (JsonSerializationException ex)
            {
                throw new MultiSafepayException(9999,
                    String.Format("{0}{1}{1}{2}",
                    "Error deserializing response. Possible error on server.",
                    Environment.NewLine,
                    response),
                    ex);
            }
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
