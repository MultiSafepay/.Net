using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class FastCheckoutOrder
    {
        [TestMethod]
        public void Orders_CreateFastCheckoutOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateFastCheckoutOrder(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "test account", "test phone", "email@email.com", "referrer", "useragent"),
                new Customer()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address1 = "Kraanspoor 39",
                    City = "Amsterdam",
                    Country = "NL",
                    
                    ZipCode = "1033SC"
                },
                    new ShoppingCart()
                    {
                        Items = new ShoppingCartItem[]
                        {
                            new ShoppingCartItem("Test Product", 1000, 2)
                        }
                    }
                );

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));

        }

    }
}
