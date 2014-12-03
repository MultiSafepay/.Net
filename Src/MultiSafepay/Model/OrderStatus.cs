using System;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderStatus
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }
        [JsonProperty("reason")]
        public string DeclinedReason { get; set; }
        [JsonProperty("reason_code")]
        public string DeclinedReasonCode { get; set; }
    }
}