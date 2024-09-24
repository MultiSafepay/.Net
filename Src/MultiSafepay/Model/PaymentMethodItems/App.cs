using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class App
    {
        [JsonProperty("has_fields")]
        public bool HasFields { get; set; }

        [JsonProperty("is_enabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("qr")]
        public AppQr Qr { get; set; }
    }
}
