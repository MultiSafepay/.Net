using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    internal class UpdateOrder
    {
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("amount", DefaultValueHandling=DefaultValueHandling.Ignore) ]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("tracktrace_code")]
        public string TrackingCode   { get; set; }
        [JsonProperty("carrier")]
        public string Carrier { get; set; }
        [JsonProperty("ship_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime ShippingDate { get; set; }
        [JsonProperty("reason")]
        public string Memo { get; set; }
    }
}