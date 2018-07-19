using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Plugin
    {
        [JsonProperty("shop")]
        public string Shop { get; set; }
        [JsonProperty("plugin_version")]
        public string PluginVersion { get; set; }
        [JsonProperty("shop_version")]
        public string ShopVersion { get; set; }
        [JsonProperty("partner")]
        public string Partner { get; set; }
        [JsonProperty("shop_root_url")]
        public string ShopRootUrl { get; set; }
    }
}