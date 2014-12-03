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

            var orderRequest = OrderRequest.CreatePayAfterDeliveryOrder(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new Customer()
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        HouseNumber = "39",
                        Address1 = "Kraanspoor",
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
            Assert.IsTrue(String.IsNullOrEmpty(result.PaymentUrl));

        }

        [TestMethod]
        public void Orders_PayAfterDeliveryOrder_SetShippingStatus()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = "890d637d2875cc063225ba7fb67732e8b9860b1b"; //ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.UpdateOrderShippedStatus("1415888074", "tracktracecode", "carrier", DateTime.Now, "additional notes");

            // Assert
            Assert.IsTrue(result.Success);
            Assert.Fail();
            // <TODO> wait until bug is fixed where order status is updated
        }
    }
}
