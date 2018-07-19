using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class SecondChance
    {
        [JsonProperty("send_email")]
        public bool SendEmail { get; set; }
    }
}