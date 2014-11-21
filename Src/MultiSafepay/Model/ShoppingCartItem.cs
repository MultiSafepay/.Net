using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCartItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("unit_price")]
        public int UnitPrice { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("merchant_item_id")]
        public string MerchantItemId { get; set; }
        [JsonProperty("tax_table_selector")]
        public string TaxTableSelector { get; set; }
        [JsonProperty("weight")]
        public Weight Weight { get; set; }
    }
}