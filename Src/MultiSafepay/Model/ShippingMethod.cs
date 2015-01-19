using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShippingMethod
    {
        public ShippingMethod(string name, double price, string currencyCodeCode)
        {
            Name = name;
            Price = price;
            CurrencyCode = currencyCodeCode;
        }

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty("allowed_areas")]
        public string[] AllowedAreas { get; set; }
        [JsonProperty("excluded_areas")]
        public string[] ExcludedAreas { get; set; }

    }
}