using MultiSafepay.Model.PaymentMethodItems;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MultiSafepay.Model
{
    public class PaymentMethod
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("tokenization")]
        public PaymentMethodItems.Tokenization Tokenization { get; set; }
        
        [JsonProperty("additional_data")]
        public PaymentMethodItems.AdditionalData AdditionalData { get; set; }
        
        [JsonProperty("apps")]
        public PaymentMethodItems.Apps Apps { get; set; }
       
        [JsonProperty("icon_urls")]
        public PaymentMethodItems.IconUrls IconUrls { get; set; }
        
        [JsonProperty("brands")]
        public IList<PaymentMethodItems.Brand> Brands { get; set; }
        
        [JsonProperty("allowed_amount")]
        public PaymentMethodItems.AllowedAmount AllowedAmount { get; set; }
        
        [JsonProperty("shopping_cart_required")]
        public bool ShoppingCartRequired { get; set; }

        [JsonProperty("allowed_countries")]
        public List<string> AllowedCountries { get; set; }

        [JsonProperty("allowed_currencies")]
        public List<string> AllowedCurrencies { get; set; }

        [JsonProperty("preferred_countries")]
        public List<string> PreferredCountries { get; set; }

        [JsonProperty("required_customer_data")]
        public List<string> RequiredCustomerData { get; set; }
       
    }
}