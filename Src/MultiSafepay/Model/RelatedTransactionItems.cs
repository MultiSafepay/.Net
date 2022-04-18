using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model
{
    public class RelatedTransactionItems
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("created")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty("modified")]
        public DateTime? ModifiedDate { get; set; }
        [JsonProperty("reference_transaction_id")]
        public string ReferenceTransactionId { get; set; }
        [JsonProperty("refund_order_id")]
        public string RefundOrderId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("items")]
        public string Items { get; set; }
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        [JsonProperty("var1")]
        public string Var1 { get; set; }
        [JsonProperty("var2")]
        public string Var2 { get; set; }
        [JsonProperty("var3")]
        public string Var3 { get; set; }
        [JsonProperty("costs")]
        public IList<CostItems> Costs { get; set; }
    }
}