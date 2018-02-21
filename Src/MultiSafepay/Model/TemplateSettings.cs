using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TemplateSettings
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("hide_logo")]
        public bool HideLogo { get; set; }
        [JsonProperty("hide_flags")]
        public bool HideFlags { get; set; }
        [JsonProperty("hide_powered")]
        public bool HidePowered { get; set; }
        [JsonProperty("hide_cart")]
        public bool HideCart { get; set; }
        [JsonProperty("hide_btn_cancel")]
        public bool HideBtnCancel { get; set; }
        [JsonProperty("hide_cc_logos")]
        public bool HideCCLogos { get; set; }
        [JsonProperty("hide_btn_all_methods")]
        public bool HideBtnAllMethods { get; set; }
    }
}
