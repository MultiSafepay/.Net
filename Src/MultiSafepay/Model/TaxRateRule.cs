using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TaxRateRule
    {
        [JsonProperty("rate")]
        public double Rate { get; set;  }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}