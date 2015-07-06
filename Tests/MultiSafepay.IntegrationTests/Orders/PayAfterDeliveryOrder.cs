using System;
using System.Collections.Generic;
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

            var orderRequest = OrderRequest.CreateDirectPayAfterDeliveryOrder(orderId, "product description", 1210, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10.0, 1, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new [] { new TaxRateRule() { Rate = 0.21 }},
                            ShippingTaxed = false
                        }
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
                        PostCode = "1033SC"
                    }
                );

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsTrue(result.PaymentUrl.StartsWith("http://example.com/success?transactionid=")); // redirect to success URL

        }

        [TestMethod]
        public void Orders_PayAfterDeliveryOrder_SetShippingStatus()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.UpdateOrderShippedStatus("22b29891-f2fa-493a-bacc-c78f0e090ddb", "tracktracecode", "carrier", DateTime.Now, "memo");

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
