using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCartItem : ShoppingCartItemObject
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
    }
}