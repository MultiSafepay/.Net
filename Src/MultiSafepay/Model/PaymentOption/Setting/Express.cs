using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Express
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
