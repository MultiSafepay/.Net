using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Gateways
{
    [TestClass]
    public class GetGateways
    {
        [TestMethod]
        public void Gateways_GetGateways()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetGateways();

            // Assert
            Assert.IsNotNull(gateways);
        }

        [TestMethod]
        public void Gateways_GetGateways_Locale()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetGateways("NL");

            // Assert
            Assert.IsNotNull(gateways);
        }

        [TestMethod]
        public void Gateways_GetGateways_RestrictCountry()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetGateways("NL");

            // Assert
            Assert.IsNotNull(gateways);
        }

        [TestMethod]
        public void Gateways_GetGateways_RestrictCurrencyMethod()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetGateways(null, "USD");

            // Assert
            Assert.IsNotNull(gateways);
        }

        [TestMethod]
        public void Gateways_GetGateways_RestrictAmount()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetGateways(null, null, 50000);

            // Assert
            Assert.IsNotNull(gateways);
        }

    }
}
