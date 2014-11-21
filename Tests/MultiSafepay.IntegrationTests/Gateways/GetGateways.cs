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
            

        }

        [TestMethod]
        public void Gateways_GetGateways_WithFilters()
        {

        }
    }
}
