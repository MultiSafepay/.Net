using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Issuers
{
    [TestClass]
    public class GetIssuers
    {
        [TestMethod]
        public void Issuers_GetIssuers()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var gateways = client.GetIssuers("iDEAL");

            // Assert
            Assert.IsNotNull(gateways);
        }
    }
}
