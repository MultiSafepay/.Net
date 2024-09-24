using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.PaymentMethods
{
    [TestClass]
    public class GetPaymentMethods
    {
        [TestMethod]
        public void PaymentMethods_GetPaymentMethods()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var methods = client.GetPaymentMethods();

            // Assert
            Assert.IsNotNull(methods);
        }

        [TestMethod]
        public void PaymentMethods_GetPaymentMethods_Locale()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var methods = client.GetPaymentMethods("NL");

            // Assert
            Assert.IsNotNull(methods);
        }

        [TestMethod]
        public void PaymentMethods_GetPaymentMethods_RestrictCountry()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var methods = client.GetPaymentMethods("NL");

            // Assert
            Assert.IsNotNull(methods);
        }

        [TestMethod]
        public void PaymentMethods_GetPaymentMethods_RestrictCurrencyMethod()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var methods = client.GetPaymentMethods(null, "USD");

            // Assert
            Assert.IsNotNull(methods);
        }

        [TestMethod]
        public void PaymentMethods_GetPaymentMethods_RestrictAmount()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var methods = client.GetPaymentMethods(null, null, 50000);

            // Assert
            Assert.IsNotNull(methods);
        }
    }
}
