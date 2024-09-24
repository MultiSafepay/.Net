﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model
{
    public class OrderResponse
    {
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("modified")]
        public DateTime? ModifiedDate { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public int AmountInCents { get; set; }

        [JsonProperty("amount_refunded")]
        public double AmountRefunded { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("financial_status")]
        public string FinancialStatus { get; set; }

        [JsonProperty("fastcheckout")]
        public string FastCheckout { get; set; }

        [JsonProperty("gateway")]
        public int GatewayId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("var1")]
        public string Var1 { get; set; }

        [JsonProperty("var2")]
        public string Var2 { get; set; }

        [JsonProperty("var3")]
        public string Var3 { get; set; }

        [JsonProperty("items")]
        public string Items { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("delivery")]
        public DeliveryAddress DeliveryAddress { get; set; }

        [JsonProperty("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }

        [JsonProperty("shopping_cart")]
        public ShoppingCartResponse ShoppingCart { get; set; }

        [JsonProperty("costs")]
        public IList<CostItems> Costs { get; set; }

        [JsonProperty("related_transactions")]
        public IList<RelatedTransactionItems> RelatedTransactions { get; set; }

        [JsonProperty("gateway_info")]
        public GatewayInfoResponse GatewayInfo { get; set; }

        //In common with redirect PaymentLink class
        [JsonProperty("payment_url")]
        public string PaymentUrl { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("events_token")]
        public string EventsToken { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("html_form")]
        public string HtmlForm { get; set; }

        [JsonProperty("custom_info")]
        public dynamic CustomInfo { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("reason_code")]
        public string ReasonCode { get; set; }

        [JsonProperty("qr")]
        public OrderQr Qr { get; set; }
    }
}