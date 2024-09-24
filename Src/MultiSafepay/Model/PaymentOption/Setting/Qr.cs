using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Qr
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
       
        [JsonProperty("autoload")]
        public bool Autoload{ get; set; }

        [JsonProperty("qr_only")]
        public bool QrOnly { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }
    }
}
