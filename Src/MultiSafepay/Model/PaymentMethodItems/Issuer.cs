using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class Issuer
    {
        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon_urls")]
        public IconUrls IconUrls { get; set; }
    }
}
