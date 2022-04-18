using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiSafepay.Model
{
    public class CaptureRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("new_order_status")]
        public string NewOrderStatus { get; set; }
        [JsonProperty("new_order_id")]
        public string NewOrderId { get; set; }
        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }
        [JsonProperty("carrier")]
        public string Carrier { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("memo")]
        public string Memo { get; set; }
    }
}
