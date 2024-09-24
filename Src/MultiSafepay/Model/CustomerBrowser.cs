using Newtonsoft.Json;
using System;

namespace MultiSafepay.Model
{
    public class CustomerBrowser
    {
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("javascript_enabled")]
        public bool JavascriptEnabled { get; set; }

        [JsonProperty("java_enabled")]
        public bool JavaEnabled{ get; set; }

        [JsonProperty("cookies_enabled")]
        public string CookiesEnabled { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("accept_header")]
        public bool AcceptHeader { get; set; }

        [JsonProperty("screen_color_depth")]
        public string ScreenColorName { get; set; }

        [JsonProperty("screen_height")]
        public string ScreenHeight { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty("zip_code")]
        public string PostCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("disable_send_email")]
        public bool DisableSendEmail { get; set; }
        [JsonProperty("browser")]
        public CustomerBrowser Browser { get; set; }
    }
}
