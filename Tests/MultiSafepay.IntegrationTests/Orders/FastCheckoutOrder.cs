using System;
using System.Collections.Generic;
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 1, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    NoShippingMethod = false,
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new List<ShippingMethod>
                        {
                            new ShippingMethod("test", 1.0, "EUR"),
                            new ShippingMethod("test2", 3.0, "EUR"),
                        }
                    },
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new [] { new TaxRateRule() { Rate = 0.21 }},
                            ShippingTaxed = true
                        }
                    }
                });
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckout_NoShippingMethod()
        {
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    NoShippingMethod = true
                }
                );
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckout_ShippingMethodPickup()
        {
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        Pickup = new ShippingMethod("Pickup Shipping", 1000, "EUR")
                    }
                });
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckout_ForeignCurrency()
        {
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateFastCheckoutOrder(orderId, "product description", 1000, "GBP",
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2, "GBP"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "GBP")
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new[] { new ShippingMethod("Shipping", 1000, "GBP") }
                    }
                });
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckout_CustomDefaultTaxTable()
        {
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateFastCheckoutOrder(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success",
                    "http://example.com/failed"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new[] { new ShippingMethod("Shipping", 1000, "EUR") }
                    },
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new[] { new TaxRateRule() { Rate = 0.05 } },
                            ShippingTaxed = true
                        }
                    }
                });


            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckout_AlternateCustomTaxTable()
        {
            var url = ConfigurationManager.AppSettings["MultiSafepayAPI"];
            var apiKey = ConfigurationManager.AppSettings["MultiSafepayAPIKey"];
            var client = new MultiSafepayClient(apiKey, url);
            var orderId = Guid.NewGuid().ToString();

            var orderRequest = OrderRequest.CreateFastCheckoutOrder(orderId, "product description", 1000, "EUR",
                new PaymentOptions("http://example.com/notify", "http://example.com/success",
                    "http://example.com/failed"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 1, "EUR")
                        {
                            TaxTableSelector = "Alternate"
                        },
                        new ShoppingCartItem("Test Product 2", 10, 1, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new[] { new ShippingMethod("Shipping", 1000, "EUR") }
                    },
                    TaxTables = new TaxTables()
                    {
                        DefaultTaxTable = new TaxTable()
                        {
                            Name = "Default",
                            Rules = new[] { new TaxRateRule() { Rate = 0.10 } },
                            ShippingTaxed = true
                        },
                        AlternateTaxTables = new []
                        {
                            new TaxTable()
                            {
                                Name = "Alternate",
                                Rules = new [] { new TaxRateRule() { Rate = 0.05 }},
                                ShippingTaxed = false
                            }
                        }
                    }
                });


            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }


        [TestMethod]
        public void Orders_CreateFastCheckoutOrder_PredefinedCustomFields()
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    NoShippingMethod = true
                });
            orderRequest.CustomFields = new []
            {
                new CustomField("acceptagreements", StandardCustomField.acceptagreements), 
                new CustomField("birthday", StandardCustomField.birthday),
                new CustomField("chamberofcommerce", StandardCustomField.chamberofcommerce),
                new CustomField("comment", StandardCustomField.comment),
                new CustomField("companyname", StandardCustomField.companyname),
                new CustomField("driverslicense", StandardCustomField.driverslicense),
                new CustomField("mobilephonenumber", StandardCustomField.mobilephonenumber),
                new CustomField("newsletter", StandardCustomField.newsletter),
                new CustomField("passportnumber", StandardCustomField.passportnumber),
                new CustomField("phonenumber", StandardCustomField.phonenumber),
                new CustomField("salutation", StandardCustomField.salutation),
                new CustomField("sex", StandardCustomField.sex),
                new CustomField("vatnumber", StandardCustomField.vatnumber)
            };
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckoutOrder_CustomField()
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    NoShippingMethod = true
                });
            orderRequest.CustomFields = new []
            {
                //new CustomField("TestField", CustomFieldType.checkbox),  
                new CustomField("TestField2", CustomFieldType.textbox) { Label = "Test Field"},
                //new CustomField("TestField3", CustomFieldType.selectbox),
                //new CustomField("TestField4", CustomFieldType.radiolist)
            };
            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

        [TestMethod]
        public void Orders_CreateFastCheckoutOrder_SetCustomerData()
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
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                        new ShoppingCartItem("Test Product 2", 10, 2, "EUR")
                    }
                },
                new CheckoutOptions()
                {
                    NoShippingMethod = true
                });

            orderRequest.Customer = new Customer()
            {
                Email = "testemail@example.com",
                Country = "Netherlands",
                FirstName = "John",
                LastName = "Doe",
                HouseNumber = "39B",
                City = "Amsterdam",
                PostCode = "1234",
                Address1 = "Kraanspoor"
            };

            // Act
            var result = client.CreateOrder(orderRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(orderRequest.OrderId, result.OrderId);
            Assert.IsFalse(String.IsNullOrEmpty(result.PaymentUrl));
        }

    }
}
