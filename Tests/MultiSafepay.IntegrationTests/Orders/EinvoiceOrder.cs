using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;

namespace MultiSafepay.IntegrationTests.Orders
{
    [TestClass]
    public class EinvoiceOrder
    {
        [TestMethod]
        public void Orders_CreateEinvoiceOrder()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateDirectEinvoiceOrder(orderId, "product description", 12100, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 100.0, 1, "EUR")
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

        [TestMethod]
        public void Orders_EinvoiceOrder_SetShippingStatus()
        {
            // Arrange
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);

            // Act
            var result = client.UpdateOrderShippedStatus("fab3ae66-9502-47c3-ba50-a8328e976554", "tracktracecode", "carrier", DateTime.Now, "memo");

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
