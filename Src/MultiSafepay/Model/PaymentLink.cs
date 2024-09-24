using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentLink
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("payment_url")]
        public string PaymentUrl { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("events_token")]
        public string EventsToken { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("qr_url")]
        public string QrUrl { get; set; }

        [JsonProperty("custom_info")]
        public dynamic CustomInfo { get; set; }

        [JsonProperty("qr")]
        public OrderQr Qr { get; set; }
    }
}