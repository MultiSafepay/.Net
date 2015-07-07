using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(string merchantItemId, string name, double unitPrice, int quantity, string currency)
        {
            MerchantItemId = merchantItemId;
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Currency = currency;
        }

        public ShoppingCartItem(string name, double unitPrice, int quantity, string currency)
        {
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Currency = currency;
        }

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
        [JsonProperty("weight")]
        public Weight Weight { get; set; }
    }
}