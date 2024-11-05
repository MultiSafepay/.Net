using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using MultiSafepay.Model;
using MultiSafepay.Model.Transactions;

namespace MultiSafepay
{
    /// <summary>
    /// Generates urls for the different operations available on the MultiSafepay API
    /// </summary>
    internal class UrlProvider
    {
        private readonly string _baseUrl;
        private string _langaugeCode;

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

        internal UrlProvider(string baseUrl, string languageCode)
            : this(baseUrl)
        {
            _langaugeCode = languageCode;
        }

        public string TransactionsUrl(TransactionsFilter param)
        {
            var queryStringComponents = new Dictionary<string, string>()
              {
                { "limit", param.Limit.HasValue ? WebUtility.UrlEncode(param.Limit.ToString()) : null },
                { "after", param.After != null ? WebUtility.UrlEncode(param.After.ToString()) : null },
                { "before", param.Before != null ? WebUtility.UrlEncode(param.Before.ToString()) : null },

                { "site_id", param.SideId.HasValue ? WebUtility.UrlEncode(param.SideId.ToString()) : null },
                { "completed_from", (param.CompletedFrom != null && param.CompletedFrom != DateTime.MinValue) ? WebUtility.UrlEncode(param.CompletedFrom.ToString("yyyy-MM-ddTHH:mm:ss")) : null },
                { "completed_until", (param.CompletedUntil != null && param.CompletedUntil != DateTime.MinValue) ? WebUtility.UrlEncode(param.CompletedUntil.ToString("yyyy-MM-ddTHH:mm:ss")) : null },
                { "created_from", (param.CreatedFrom != null && param.CreatedFrom != DateTime.MinValue) ? WebUtility.UrlEncode(param.CreatedFrom.ToString("yyyy-MM-ddTHH:mm:ss")) : null },
                { "created_until", (param.CreatedUntil != null && param.CreatedUntil != DateTime.MinValue) ? WebUtility.UrlEncode(param.CreatedUntil.ToString("yyyy-MM-ddTHH:mm:ss")) : null },
                { "debit_credit", param.DebitCredit != null ? WebUtility.UrlEncode(param.DebitCredit.ToString()) : null },

                { "financial_status", (param.FinancialStatus != null && param.FinancialStatus.Count > 0) ? WebUtility.UrlEncode(String.Join(",", param.FinancialStatus)) : null },
                { "status", (param.Status != null && param.Status.Count > 0) ? WebUtility.UrlEncode(String.Join(",", param.Status)) : null },
                { "type", (param.Type != null && param.Type.Count > 0) ? WebUtility.UrlEncode(String.Join(",", param.Type)) : null },
              }
            .Where(x => !String.IsNullOrEmpty(x.Value));

            var queryString = String.Join("&", queryStringComponents.Select(x => String.Format("{0}={1}", x.Key, x.Value)));

            if (!String.IsNullOrEmpty(queryString))
            {
                return FormatLanguage(_baseUrl + "transactions?" + queryString, _langaugeCode);
            }

            return FormatLanguage(_baseUrl + "transactions", _langaugeCode);
        }

        public string PaymentMethodsUrl(
            string countryCode = null, 
            string currency = null, 
            int? amount = null, 
            int? includeCoupons = null, 
            int? groupCards = null, 
            string application = null
            )
        {
            var queryStringComponents = new Dictionary<string, string>()
            {
                {"country", WebUtility.UrlEncode(countryCode)},
                {"include_coupons", amount.HasValue ? WebUtility.UrlEncode(includeCoupons.ToString()) : null},
                {"group_cards", amount.HasValue ? WebUtility.UrlEncode(groupCards.ToString()) : null},
                {"currency", WebUtility.UrlEncode(currency)},
                {"application", WebUtility.UrlEncode(application)},
                {"amount", amount.HasValue ? WebUtility.UrlEncode(amount.ToString()) : null}
            }
                .Where(x => !String.IsNullOrEmpty(x.Value));

            var queryString = String.Join("&", queryStringComponents.Select(x => String.Format("{0}={1}", x.Key, x.Value)));


            if (!String.IsNullOrEmpty(queryString))
            {
                return FormatLanguage(_baseUrl + "payment-methods?" + queryString, _langaugeCode);
            }

            return FormatLanguage(_baseUrl + "payment-methods", _langaugeCode);
        }

        public string PaymentMethodUrl(string methodId)
        {
            return FormatLanguage(_baseUrl + "payment-methods/" + methodId, _langaugeCode);
        }

        public string GatewaysUrl(string countryCode = null, string currency = null, int? amount = null)
        {
            var queryStringComponents = new Dictionary<string, string>()
            {
                {"country", WebUtility.UrlEncode(countryCode)},
                {"currency", WebUtility.UrlEncode(currency)},
                {"amount", amount.HasValue ? WebUtility.UrlEncode(amount.ToString()) : null}
            }
                .Where(x => !String.IsNullOrEmpty(x.Value));

            var queryString = String.Join("&", queryStringComponents.Select(x => String.Format("{0}={1}", x.Key, x.Value)));


            if (!String.IsNullOrEmpty(queryString))
            {
                return FormatLanguage(_baseUrl + "gateways?" + queryString, _langaugeCode);
            }

            return FormatLanguage(_baseUrl + "gateways", _langaugeCode);
        }

        public string GatewayUrl(string gatewayName)
        {
            return FormatLanguage(_baseUrl + "gateways/" + gatewayName, _langaugeCode);
        }

        public string IssuersUrl(string gatewayName)
        {
            return FormatLanguage(_baseUrl + "issuers/" + gatewayName, _langaugeCode);
        }

        public string OrderUrl(string orderId)
        {
            return FormatLanguage(_baseUrl + "orders/" + orderId, _langaugeCode);
        }

        public string TransactionUrl(string transactionId)
        {
            return FormatLanguage(_baseUrl + "transactions/" + transactionId, _langaugeCode);
        }

        public string PaymentLinkUrl(string orderId)
        {
            return FormatLanguage(_baseUrl + "orders/" + orderId + "/paymentlink", _langaugeCode);
        }

        public string OrdersUrl()
        {
            return FormatLanguage(_baseUrl + "orders", _langaugeCode);
        }

        public string OrderRefundsUrl(string orderId)
        {
            return FormatLanguage(_baseUrl + "orders/" + orderId + "/refunds", _langaugeCode);
        }

        public string OrderCaptureUrl(string orderId)
        {
            return FormatLanguage(_baseUrl + "orders/" + orderId + "/capture", _langaugeCode);
        }

        public string OrderVoidUrl(string orderId)
        {
            return FormatLanguage(_baseUrl + "capture/" + orderId, _langaugeCode);
        }

        public string CustomerTokensUrl(string customerReference)
        {
            return FormatLanguage(_baseUrl + "recurring/" + customerReference, _langaugeCode);
        }

        public string DeleteTokenUrl(string customerReference, string token)
        {
            return FormatLanguage(_baseUrl + "recurring/" + customerReference + "/remove/" + token, _langaugeCode);
        }

        private string FormatLanguage(string baseUrl, string langaugeCode)
        {
            if (String.IsNullOrEmpty(langaugeCode))
            {
                return baseUrl;
            }

            if (baseUrl.Contains("?"))
            {
                return baseUrl + "&locale=" + langaugeCode.ToLower();
            }
            return baseUrl + "?locale=" + langaugeCode.ToLower();
        }
    }
}
