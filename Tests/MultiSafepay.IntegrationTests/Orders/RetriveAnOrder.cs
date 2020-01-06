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
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string orderId = "298f61a3-7104-4d22-a129-de9293091ee5";
            var result = client.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderId, result.OrderId);
        }

        [TestMethod]
        public void Orders_RetrieveOrderWithShoppingCart()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string orderId = "a2b9a099-67b0-4a99-938c-1fb430ab1a33";
            var result = client.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderId, result.OrderId);
            Assert.IsNotNull(result.ShoppingCart.Items[0]);
        }

        [TestMethod]
        public void Orders_RetriveOrder_OrderNotFound()
        {
            // Arrange
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            const string orderId = "order id that doesn't exist";
            var result = client.GetOrder(orderId);

            // Assert
            Assert.IsNull(result);
        }
    }
}