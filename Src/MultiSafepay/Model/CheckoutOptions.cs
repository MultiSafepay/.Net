using System.Collections;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class CheckoutOptions
    {
        [JsonProperty("tax_tables")]
        public TaxTables TaxTables { get; set; }
        [JsonProperty("shipping_methods")]
        public ShippingMethods ShippingMethods { get; set; }
        [JsonProperty("rounding_policy")]
        public RoundingPolicy RoundingPolicy { get; set; }
        [JsonProperty("no_shipping_method")]
        public bool NoShippingMethod { get; set; }
    }
}
