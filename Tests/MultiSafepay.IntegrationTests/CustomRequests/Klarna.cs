using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using System.Configuration;

namespace MultiSafepay.IntegrationTests.CustomRequests
{
    [TestClass]
    public class Klarna
    {
        private static MultiSafepayClient Client { get; set; }
        private void setClient()
        {
            var url = Settings.MultiSafePayUrl;
            var apiKey = Settings.ApiKey;
            Client = new MultiSafepayClient(apiKey, url);
        }

        [TestMethod]
        public void CustomRequests_Klarna_Direct()
        {
            this.setClient();
            var orderId = Guid.NewGuid().ToString();
           
            var order = new Order
            {
                Type = OrderType.Direct,
                OrderId = orderId,
                GatewayId = "KLARNA",
                AmountInCents = 1210,
                CurrencyCode = "EUR",
                Description = ".Net wrapper - Klarna Direct",
                Customer = new Customer()
                {
                    FirstName = "Testperson-nl",
                        LastName = "Approved",
                        HouseNumber = "1/XI",
                        Address1 = "Neherkade",
                        City = "Gravenhage",
                        Country = "NL",
                        PostCode = "2521VA",
                },
                DeliveryAddress = new DeliveryAddress()
                {
                    FirstName = "Testperson-nl",
                    LastName = "Approved",
                    HouseNumber = "1/XI",
                    Address1 = "Neherkade",
                    City = "Gravenhage",
                    Country = "NL",
                    PostCode = "2521VA",
                },
                GatewayInfo = new GatewayInfo()
                {
                    Birthday = new DateTime(1970, 07, 10),
                    Gender = "male",
                    Phone = "+31 (0)20 8500 500",
                    Email = "test@multisafepay.com"
                },
                ShoppingCart = new ShoppingCart()
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("10001", "Test Product", 10.0, 1, "EUR")
                    }
                },
                CheckoutOptions = new CheckoutOptions
                {
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new[] 
                            { 
                                new TaxRateRule() { Rate = 0.21 } 
                            },
                            ShippingTaxed = false
                        }
                    }
                }
            };
           
            // Act
            var result = Client.CustomOrder(order);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.Status));
        }
    }
}