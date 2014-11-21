using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShippingMethods
    {
        [JsonProperty("flat_rate_shipping")]
        public IList<ShippingMethod> FlatRateShippingMethods { get; set; }
        [JsonProperty("pickup")]
        public ShippingMethod Pickup { get; set; }
    }
}