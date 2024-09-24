using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class Pay
    {
        [JsonProperty("redirect_on_expired")]
        public bool RedirectOnExpired { get; set; }
       
        [JsonProperty("group_cards")]
        public bool GroupCards{ get; set; }
    }
}
