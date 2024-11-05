﻿using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class Customer
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("forwarded_ip")]
        public string ForwardedIp { get; set; }

        [JsonProperty("referrer")]
        public string Referrer{ get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("company")]
        public bool Company { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

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

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("disable_send_email")]
        public bool DisableSendEmail { get; set; }

        [JsonProperty("browser")]
        public CustomerBrowser Browser { get; set; }
    }
}
