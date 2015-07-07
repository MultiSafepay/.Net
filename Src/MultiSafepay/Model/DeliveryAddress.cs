using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class DeliveryAddress
    {
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
    }
}
