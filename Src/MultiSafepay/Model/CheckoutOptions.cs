﻿using Newtonsoft.Json;

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

        [JsonProperty("use_shipping_notification")]
        public bool UseShippingNotification { get; set; }

        [JsonProperty("validate_cart")]
        public bool ValidateCart { get; set; }
    }
}