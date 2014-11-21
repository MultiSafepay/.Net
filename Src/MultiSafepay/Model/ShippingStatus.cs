using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShippingStatus
    {
        [JsonProperty("tracktrace_code")]
        public string TracktraceCode { get; set; }
        [JsonProperty("carrier")]
        public string Carrier { get; set; }
        [JsonProperty("ship_date")]
        public string ShipDate { get; set; }
        [JsonProperty("memo")]
        public string Memo { get; set; }
    }
}
