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
            var result = client.GetPaymentLink("e716768b-ea49-44ac-b4df-9a293c0fe6c0");

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
            var result = client.GetPaymentLink(" order id that doesn't exist ");

            // Assert
            Assert.IsNull(result);
        }
    }
}
