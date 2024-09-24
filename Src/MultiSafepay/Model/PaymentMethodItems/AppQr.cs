using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class AppQr
    {
        [JsonProperty("supported")]
        public bool Supported { get; set; }
    }
}
