﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using MultiSafepay.Model;
using MultiSafepay.Model.Transactions;
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
        private bool _DEBUG = false;
        private bool _disposed;
        public string Language { get; set; }

        public MultiSafepayClient(
            string apiKey, 
            string apiUrl = "https://api.multisafepay.com/v1/json/", 
            string languageCode = null,
            bool debug = false
        )
        {
            _DEBUG = debug;

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            _client = new WebClient();
            _client.Headers["api_key"] = apiKey;
            _client.Headers[HttpRequestHeader.ContentType] = "application/json";
            _client.Encoding = System.Text.Encoding.UTF8;
            
            _urlProvider = new UrlProvider(apiUrl, languageCode);
        }
        /// <summary>
        /// Helper - returns an object as Json string
        /// </summary>
        /// <param name="obj"></param>
        public String serializeObject(dynamic obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        #region API Methods
        /// <summary>
        /// Retrieves details about a particular order
        /// </summary>
        /// <param name="orderId">The client specified order id</param>
        public Model.Transactions.Transaction GetTransaction(string transactionId)
        {
            var response = DoRequest<Model.Transactions.Transaction>(_urlProvider.TransactionUrl(transactionId));
            return response == null ? null : response.Data;
        }

        /// <summary>
        /// Gets a list of Transactions
        /// </summary>
        /// 
        public TransactionsResponse GetTransactions(TransactionsFilter filter)
        {
            var response = DoRequest<Model.Transactions.Transaction[]>(_urlProvider.TransactionsUrl(filter));
            return (
                response != null ?
                    new TransactionsResponse()
                    {
                        Success = response.Success,
                        Data = response.Data,
                        Pager = response.Pager
                    } : 
                    null
            );
        }

        /// <summary>
        /// Gets a list of all payment methods configured for the users account with extended information.
        /// </summary>
        public PaymentMethod[] GetPaymentMethods(
            string countryCode = null,
            string currency = null,
            int? amount = null,
            int? includeCoupons = null,
            int? groupCards = null,
            string application = null
            )
        {
            var response = DoRequest<PaymentMethod[]>(_urlProvider.PaymentMethodsUrl(countryCode, currency, amount, includeCoupons, groupCards, application));
            return response.Data;
        }

        /// <summary>
        /// Gets data for a specific payment method with extended information.
        /// </summary>
        /// <param name="methodId">The unique identifier for the payment method</param>
        public PaymentMethod GetPaymentMethod(string methodId)
        {
            var response = DoRequest<PaymentMethod>(_urlProvider.PaymentMethodUrl(methodId));
            return response.Data;
        }

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
        /// Create a generic order
        /// </summary>
        /// <param name="orderRequest">OrderRequest object populated with the order details</param>
        /// <returns>The payment link to redirect the customer and other variables for a direct transaction</returns>
        public OrderResponse CustomOrder(Order order)
        {
            var response = DoRequest<OrderResponse>(_urlProvider.OrdersUrl(), order);
            return response.Data;
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
        /// Create an order that will return full order structure
        /// </summary>
        /// <param name="orderRequest">OrderRequest object populated with the order details</param>
        /// <returns>The payment link to redirect the customer and other variables for a direct transaction</returns>
        public OrderResponse CreateOrderDirect(OrderRequest orderRequest)
        {
            var response = DoRequest<OrderResponse>(_urlProvider.OrdersUrl(), orderRequest);
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
        /// Cacnel an order by a given orderId
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// 
        public OrderResponse OrderCancel(string orderId)
        {
            var response = DoRequest<OrderResponse>(_urlProvider.OrderCancelUrl(orderId),
                null,
                "POST"
            );
            return response.Data;
        }

        /// <summary>
        /// Updates an order by a given orderId
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// <param name="UpdateOrder">UpdateOrder Supported values</param>
        /// 
        public OrderUpdateResult OrderUpdate(string orderId, UpdateOrder updateOrder)
        {
            var response = DoRequest<OrderUpdateResult>(_urlProvider.OrderUrl(orderId),
                updateOrder,
                "PATCH"
            );
            return response.Data;
        }

        /// <summary>
        /// Issues a refund for a particular refund in order
        /// </summary>
        /// <param name="orderId">The client specified unique order id to update</param>
        /// <param name="refundId">The refundId</param>
        /// <param name="status">Status</param>
        /// <param name="description">A description for the refund transaction</param>
        /// <returns>The MultiSafepay unique identifier for the refund transaction</returns>
        public RefundResult UpdateRefund(string orderId, string refundId, UpdateOrder updateOrder)
        {
            var response = DoRequest<RefundResult>(_urlProvider.OrderRefundsUpdateUrl(orderId, refundId), 
                updateOrder, 
                "PATCH"
            );
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

        /// <summary>
        /// Do a partial/full capture of an order
        /// </summary>
        /// <param name="orderId">Inique identifier of the order</param>
        /// <param name="amoutToCaptureInCents">The amount (in cents) that the customer needs to pay.</param>
        /// <param name="invoiceId">Update an existing order with a reference to your internal invoice id. The invoice id will be added to financial reports and exports generated within MultiSafepay Control (max. 50 chars)</param>
        /// <param name="reason">Add a short text memo based on the capture reason of the order</param>
        /// <param name="carrier">The name of the shipping company delivering the customer’s order</param>
        /// <param name="memo">Add a short action text memo mentioning the shipping status of the order</param>
        /// <param name="newOrderId">New order id in case of partial capture</param>
        /// <returns>Result of transaction</returns>
        public CaptureResult CaptureOrder(string orderId, int amoutToCaptureInCents, string invoiceId, string reason, string newOrderId = null, string carrier = null, string memo = null)
        {
            var response = DoRequest<CaptureResult>(_urlProvider.OrderCaptureUrl(orderId),
               new CaptureRequest()
               {
                   Amount = amoutToCaptureInCents,
                   NewOrderStatus = "completed",
                   NewOrderId = newOrderId,
                   InvoiceId = invoiceId,
                   Reason = reason,
                   Carrier = carrier,
                   Memo = memo
               }, "POST");
            return response.Data;
        }

        /// <summary>
        /// Void Authorization/Reservation of an order
        /// </summary>
        /// <param name="orderId">The unique identifier from your system for the order. If the values are only numbers the type will be integer, otherwise it will be string. Required. Max 50 char</param>
        /// <param name="reason">Add a short text memo based on the void reason of the order</param>
        /// <returns>Result of transaction</returns>
        public SimpleResult VoidOrder (string orderId, string reason)
        {
            var response = DoRequest<SimpleResult>(_urlProvider.OrderVoidUrl(orderId),
              new VoidRequest()
              {
                  Reason = reason,
                  Status = "cancelled",
              }, "PATCH");
            return response.Data;
        }

        /// <summary>
        /// Get all customer tokens
        /// </summary>
        /// <param name="customerReference">Customer unique identifier</param>
        /// <returns>Tokens with all customer payments saved information</returns>
        public TokenResponse GetCustomerTokens(string customerReference)
        {
            var response = DoRequest<TokenResponse>(_urlProvider.CustomerTokensUrl(customerReference));
            return response.Data;
        }

        /// <summary>
        /// Delete payment token
        /// </summary>
        /// <param name="customerReference"></param>
        /// <returns></returns>
        public TokenDeleteResponse DeleteToken(string customerReference, string token)
        {
            var response = DoRequest<TokenDeleteResponse>(_urlProvider.DeleteTokenUrl(customerReference, token), new { }, "DELETE");
            return response.Data;
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
                if (_DEBUG)
                {
                    Trace.WriteLine(String.Empty);
                    Trace.WriteLine("GET - " + url);
                }
                var response = _client.DownloadString(url);
                if (_DEBUG)
                {
                    Trace.WriteLine(response);
                }
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
                if (_DEBUG)
                {
                    Trace.WriteLine(responseContents);
                }
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

                if (_DEBUG)
                {
                    Trace.WriteLine(String.Empty);
                    Trace.WriteLine(httpMethod + "- " + url);
                    Trace.WriteLine(serializedRequest);
                }

                var response = _client.UploadString(url, httpMethod, serializedRequest);
                if (_DEBUG)
                {
                    Trace.WriteLine(response);
                }
                return DeserializeResult<T>(response);
            }
            catch (WebException ex)
            {
                //Response from server is not empty
                if (ex.Response != null)
                {
                    var reader = new StreamReader(ex.Response.GetResponseStream());
                    var response = reader.ReadToEnd();
                    if (_DEBUG)
                    {
                        Trace.WriteLine(response);
                    }

                    ResponseMessage r = null;
                    try
                    {
                        r = JsonConvert.DeserializeObject<ResponseMessage>(response);
                    }
                    catch (JsonReaderException jex)
                    {
                        //Error reading / parsing JSON returned by server or wrongly provided url.
                        throw new MultiSafepayException(9998,
                            String.Format("{0}{1}{1}{2}", "Error deserializing JSON response.", Environment.NewLine, url), 
                            jex);
                    }
                    finally
                    {
                        if (r != null) {
                            throw new MultiSafepayException(r.ErrorCode, r.ErrorInfo, ex);
                        }
                    }
                }
                //No response from server, possible 404 or timeout
                throw new MultiSafepayException(9999,
                    String.Format("{0}{1}{1}{2}", "Error deserializing response. Possible error on server.", Environment.NewLine,url),
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
                    var errorCode = (serializedResult.ErrorCode <= 0 ? 0 : serializedResult.ErrorCode);
                    var errorInfo = (serializedResult.ErrorInfo != null ? serializedResult.ErrorInfo.ToString() : null);
                    if (errorInfo != null && serializedResult.Message != null)
                    {
                        errorInfo = serializedResult.Message;
                    }
                    throw new MultiSafepayException(errorCode, errorInfo);
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