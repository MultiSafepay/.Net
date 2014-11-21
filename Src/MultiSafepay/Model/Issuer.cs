using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Issuer
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}