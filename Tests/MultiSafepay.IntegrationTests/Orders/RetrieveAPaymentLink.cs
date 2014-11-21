using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class RetrieveAPaymentLink
    {
        [TestMethod]
        public void Orders_RetrivePaymentLink()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.GetPaymentLink("546f2d1cd1d7c");

            // Assert
        }
    }
}
