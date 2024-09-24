using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Connect
    {
        [JsonProperty("merge")]
        public bool Merge { get; set; }

        [JsonProperty("group_cards")]
        public bool GroupCards { get; set; }

        [JsonProperty("selected")]
        public string Selected { get; set; }

        [JsonProperty("qr")]
        public Qr Qr { get; set; }

        [JsonProperty("mobile_device")]
        public MobileDevice MobileDevice { get; set; }

        [JsonProperty("redirect_mode")]
        public string RedirectMode { get; set; }

        [JsonProperty("express")]
        public Express Express { get; set; }
    }
}
