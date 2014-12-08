using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class PaymentLink
    {
        [TestMethod]
        public void Orders_RetrievePaymentLink()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.GetPaymentLink("5feea366-f8f9-453b-9fdb-03ec49ba5f98");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }


        [TestMethod]
        public void Orders_RetrivePaymentLink_NotFoundReturnsNull()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.GetPaymentLink("orderthatdoesnotexist");

            // Assert
            Assert.IsNull(result);
        }
    }
}
