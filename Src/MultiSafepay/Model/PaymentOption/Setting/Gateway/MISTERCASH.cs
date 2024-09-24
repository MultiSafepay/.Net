using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class MISTERCASH
    {
        [JsonProperty("qr")]
        public Qr Qr { get; set; }
       
        [JsonProperty("mobile_device")]
        public MobileDevice MobileDevice{ get; set; }
    }
}
