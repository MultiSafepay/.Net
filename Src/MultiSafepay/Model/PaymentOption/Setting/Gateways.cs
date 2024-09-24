using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Gateways
    {
        [JsonProperty("MISTERCASH")]
        public string MISTERCASH { get; set; }

        [JsonProperty("IDEAL")]
        public string IDEAL { get; set; }

        [JsonProperty("coupons")]
        public string Coupons { get; set; }
    }
}
