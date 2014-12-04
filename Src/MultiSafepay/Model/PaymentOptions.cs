using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentOptions
    {
        public PaymentOptions()
        {
            CloseWindow = true;
        }

        public PaymentOptions(string notificationUrl, string successRedirectUrl, string cancelRedirectUrl)
            :this()
        {
            NotificationUrl = notificationUrl;
            SuccessRedirectUrl = successRedirectUrl;
            CancelRedirectUrl = cancelRedirectUrl;
        }

        [JsonProperty("notification_url")]
		public string NotificationUrl { get; set; }
        [JsonProperty("redirect_url")]
		public string SuccessRedirectUrl { get; set; }
        [JsonProperty("cancel_url")]
		public string CancelRedirectUrl { get; set; }
        [JsonProperty("close_window")]
		public bool CloseWindow { get; set; }
	}
}
