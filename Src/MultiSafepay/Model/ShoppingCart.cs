using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCart
    {
        [JsonProperty("items")]
        public IList<ShoppingCartItem> Items { get; set; }
    }
}
