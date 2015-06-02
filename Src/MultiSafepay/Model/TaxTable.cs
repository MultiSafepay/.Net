using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class TaxTable
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("shipping_taxed")]
        public bool ShippingTaxed { get; set; }
        [JsonProperty("rules")]
        public TaxRateRule[] Rules { get; set; }
        [JsonProperty("standalone")]
        public bool StandAlone { get; set; }
    }
}