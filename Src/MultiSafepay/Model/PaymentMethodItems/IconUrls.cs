using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class IconUrls
    {
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("vector")]
        public string Vector { get; set; }
    }
}
