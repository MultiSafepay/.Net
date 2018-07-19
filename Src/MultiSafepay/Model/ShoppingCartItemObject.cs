using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCartItemObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("merchant_item_id")]
        public string MerchantItemId { get; set; }
        [JsonProperty("tax_table_selector")]
        public string TaxTableSelector { get; set; }
        [JsonProperty("cashback")]
        public string Cashback { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("product_url")]
        public string ProductUrl { get; set; }
        [JsonProperty("weight")]
        public Weight Weight { get; set; }
    }
}