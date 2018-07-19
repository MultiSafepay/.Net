using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class ShoppingCartResponse
    {
        [JsonProperty("items")]
        public IList<ShoppingCartItemObject> Items { get; set; }
    }
}