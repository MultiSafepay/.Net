using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShippingMethod
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("allowed_areas")]
        public string AllowedAreas { get; set; }
        [JsonProperty("excluded_areas")]
        public string ExcludedAreas { get; set; }

    }
}