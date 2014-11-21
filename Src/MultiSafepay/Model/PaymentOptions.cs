using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentOptions
    {
        public PaymentOptions()
        {
            CloseWindow = true;
        }

        [JsonProperty("notification_url")]
		public string NotificationUrl { get; set; }
        [JsonProperty("redirect_url")]
		public string RedirectUrl { get; set; }
        [JsonProperty("cancel_url")]
		public string CancelUrl { get; set; }
        [JsonProperty("close_window")]
		public bool CloseWindow { get; set; }
	}
}
