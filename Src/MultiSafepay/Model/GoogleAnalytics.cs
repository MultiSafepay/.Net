using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class GoogleAnalytics
    {
        [JsonProperty("account")]
        public string Account { get; set; }
    }
}
