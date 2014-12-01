using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentOptions
    {
        public PaymentOptions()
        {
            CloseWindow = true;
        }

        public PaymentOptions(string notificationUrl, string successSuccessRedirectUrl, string cancelRedirectRedirectUrl)
            :this()
        {
            NotificationUrl = notificationUrl;
            SuccessRedirectUrl = successSuccessRedirectUrl;
            CancelRedirectUrl = cancelRedirectRedirectUrl;
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
