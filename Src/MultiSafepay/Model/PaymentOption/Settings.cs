using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption
{
    public class Settings
    {
        [JsonProperty("qr")]
        public Setting.Qr Qr{ get; set; }

        [JsonProperty("mobile_device")]
        public Setting.MobileDevice MobileDevice{ get; set; }

        [JsonProperty("pay")]
        public Setting.Pay Pay { get; set; }

        [JsonProperty("gateways")]
        public Setting.Gateways Gateways { get; set; }

        [JsonProperty("coupons")]
        public Setting.Coupons Coupons { get; set; }

        [JsonProperty("connect")]
        public Setting.Connect Connect { get; set; }
    }
}
