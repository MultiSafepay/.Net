using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model.PaymentMethodItems
{
    public class Brand
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("allowed_countries")]
        public List<string> AllowedCountries { get; set; }

        [JsonProperty("icon_urls")]
        public IconUrls IconUrls { get; set; }
    }
}
