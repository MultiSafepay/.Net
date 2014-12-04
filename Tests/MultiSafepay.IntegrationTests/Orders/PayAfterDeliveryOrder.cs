using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class PayAfterDeliveryOrder
    {
        [TestMethod]
        public void Orders_CreatePayAfterDeliveryOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateDirectPayAfterDeliveryOrder(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2),
                        new ShoppingCartItem("Test Product 2", 10, 2)
                    }
                },
                new Customer()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        HouseNumber = "39",
                        Address1 = "Kraanspoor",
                        City = "Amsterdam",
                        Country = "NL",
                        ZipCode = "1033SC"
                    }
                );

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsTrue(String.IsNullOrEmpty(result.PaymentUrl));

        }

        [TestMethod]
        public void Orders_PayAfterDeliveryOrder_SetShippingStatus()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.UpdateOrderShippedStatus("546dd9aeb49aa", "tracktracecode", "carrier", DateTime.Now);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
