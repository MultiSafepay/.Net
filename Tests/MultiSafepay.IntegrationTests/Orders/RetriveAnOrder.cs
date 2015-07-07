using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class RetrieveAnOrder
    {
        [TestMethod]
        public void Orders_RetrieveOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string orderId = "2669a4d2-064e-4bb6-bc38-684d108783f0";
            var result = client.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderId, result.OrderId);
        }

        [TestMethod]
        public void Orders_RetriveOrder_OrderNotFound()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string orderId = "order id that doesn't exist";
            var result = client.GetOrder(orderId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
