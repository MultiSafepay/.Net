using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class KlarnaOrder
    {
        [TestMethod]
        public void Orders_CreateKlarnaOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateDirectKlarnaOrder(orderId, "product description", 1210, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.Klarna(new DateTime(1970, 07, 10), "male", "+31 (0)20 8500 500", "test@multisafepay.com"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("10001", "Test Product", 10.0, 1, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new[] { new TaxRateRule() { Rate = 0.21 } },
                            ShippingTaxed = false
                        }
                    }
                },
                new Customer()
                    {
                        FirstName = "Testperson-nl",
                        LastName = "Approved",
                        HouseNumber = "1/XI",
                        Address1 = "Neherkade",
                        City = "Gravenhage",
                        Country = "NL",
                        PostCode = "2521VA",
                    },
               new DeliveryAddress()
                    {
                        FirstName = "Testperson-nl",
                        LastName = "Approved",
                        HouseNumber = "1/XI",
                        Address1 = "Neherkade",
                        City = "Gravenhage",
                        Country = "NL",
                        PostCode = "2521VA",
                    }
                );

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsTrue(result.PaymentUrl.StartsWith("http://example.com/success?transactionid=")); // redirect to success URL

        }
    }
}
