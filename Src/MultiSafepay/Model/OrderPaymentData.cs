using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderPaymentData
    {
        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}