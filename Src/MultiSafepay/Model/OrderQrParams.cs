using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class OrderQrParams
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}