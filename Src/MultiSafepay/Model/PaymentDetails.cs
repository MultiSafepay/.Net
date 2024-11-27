using Newtonsoft.Json;

namespace MultiSafepay.Model
{
    public class PaymentDetails
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("recurring_id")]
        public string RecurringId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("external_transaction_id")]
        public string ExternalTransactionId { get; set; }

        [JsonProperty("last4")]
        public string Last4Digits { get; set; }

        [JsonProperty("issuer_bin")]
        public string IssuerBin { get; set; }

        [JsonProperty("issuer_country_code")]
        public string IssuerCountryCode { get; set; }

        [JsonProperty("account_iban")]
        public string AccountIban { get; set; }

        [JsonProperty("account_bic")]
        public string AccountBic { get; set; }

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("card_acceptor_id")]
        public string CardAcceptorId { get; set; }

        [JsonProperty("card_acceptor_location")]
        public string CardAcceptorLocation { get; set; }

        [JsonProperty("card_acceptor_name")]
        public string CardAcceptorName { get; set; }

        [JsonProperty("card_additional_response_data")]
        public dynamic CardAdditionalResponseData { get; set; }

        [JsonProperty("card_authentication_result")]
        public string CardAuthenticationResult { get; set; }

        [JsonProperty("card_entry_mode")]
        public string CardEntityMode { get; set; }

        [JsonProperty("card_expiry_date")]
        public string CardExpiryDate { get; set; }

        [JsonProperty("card_funding")]
        public string CardFunding { get; set; }

        [JsonProperty("card_program")]
        public string CardProgram { get; set; }

        [JsonProperty("card_product")]
        public string CardProduct { get; set; }

        [JsonProperty("card_product_type")]
        public string CardProductType { get; set; }

        [JsonProperty("card_sequence_number")]
        public string CardSecuenceNumber { get; set; }

        [JsonProperty("card_verification_result")]
        public string CardVerificationResult { get; set; }

        [JsonProperty("cardholder_verification_method")]
        public string CardVerificationMethod { get; set; }

        [JsonProperty("cardholder_verification_result")]
        public string CardHolderVerificationResult { get; set; }

        [JsonProperty("emv")]
        public dynamic Emv { get; set; }

        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("recurring_flow")]
        public string RecurringFlow { get; set; }

        [JsonProperty("recurring_model")]
        public string RecurringModel { get; set; }

        [JsonProperty("scheme_reference_id")]
        public string SchemeReferenceId { get; set; }

        [JsonProperty("acquirer_reference_number")]
        public string AcquirerReferenceNumber { get; set; }
    }
}