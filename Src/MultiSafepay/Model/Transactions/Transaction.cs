using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model.Transactions
{
    public class Transaction
    {
        [JsonProperty("created")]
        public DateTime? Created { get; set; }

        [JsonProperty("completed")]
        public DateTime? Completed { get; set; }

        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("debit_credit")]
        public string CreditDebit { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("financial_status")]
        public string FinancialStatus { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("net")]
        public int Net { get; set; }

        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("reason_code")]
        public string ReasonCode { get; set; }

        [JsonProperty("site_id")]
        public int SiteId { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("var1")]
        public string Var1 { get; set; }

        [JsonProperty("var2")]
        public string Var2 { get; set; }

        [JsonProperty("var3")]
        public string Var3 { get; set; }

        [JsonProperty("costs")]
        public IList<CostItems> Costs { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    }
}
