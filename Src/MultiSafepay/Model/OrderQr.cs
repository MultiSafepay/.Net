using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderQr
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("params")]
        public OrderQrParams Params { get; set; }

    }
}
