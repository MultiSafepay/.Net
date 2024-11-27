using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class UpdateOrder
    {

        [JsonProperty("exclude_order")]
        public bool? ExcludeOrder { get; set; }

        [JsonProperty("extend_expiration")]
        public bool? ExtendExpiration { get; set; }

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("invoice_url")]
        public string InvoiceUrl { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount", DefaultValueHandling=DefaultValueHandling.Ignore) ]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tracktrace_code")]
        public string TrackingCode { get; set; }

        [JsonProperty("tracktrace_url")]
        public string TrackTraceUrl { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("ship_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime ShippingDate { get; set; }

        [JsonProperty("po_number")]
        public string PoNumber { get; set; }

        [JsonProperty("reason")]
        public string Memo { get; set; }

        [JsonProperty("new_order_id")]
        public string NewOrderId { get; set; }
    }
}