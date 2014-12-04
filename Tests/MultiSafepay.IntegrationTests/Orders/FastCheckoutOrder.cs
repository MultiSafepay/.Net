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
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2),
                        new ShoppingCartItem("Test Product 2", 10, 2)
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new []
                        {
                            new ShippingMethod("shipping method 1", 10, "EUR"),
                            new ShippingMethod("shipping method 2", 10, "EUR")
                        }
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
