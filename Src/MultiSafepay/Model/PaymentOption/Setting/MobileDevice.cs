using Newtonsoft.Json;

namespace MultiSafepay.Model.PaymentOption.Setting
{
    public class MobileDevice
    {
        [JsonProperty("app_pay_button_position")]
        public string AppPayButtonPostion { get; set; }
       
        [JsonProperty("app_pay_button_disabled")]
        public bool AppPayButtonDisabled{ get; set; }
    }
}
