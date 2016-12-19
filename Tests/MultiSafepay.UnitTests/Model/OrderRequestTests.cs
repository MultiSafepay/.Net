using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class OrderRequestTests
    {
        [TestMethod]
        public void Order_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var order = OrderRequest.CreateRedirect(null, null, 1000, null, 
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var serializedObject = JsonConvert.SerializeObject(order);

            // Assert
            Assert.AreEqual(@"{
	            ""type"": ""redirect"",
	            ""order_id"": null,
                ""recurring_id"":null,
	            ""currency"": null,
	            ""amount"": 1000,
                ""gateway"": null,
	            ""description"": null,
	            ""var1"": null,
	            ""var2"": null,
	            ""var3"": null,
                ""custom_info"":{},
	            ""items"": null,
	            ""manual"": null,
	            ""days_active"": null,
                ""gateway_info"":null,
                ""payment_options"": {
                    ""notification_url"": ""http://example.com/notify"",
                    ""redirect_url"": ""http://example.com/success"",
                    ""cancel_url"": ""http://example.com/failed"",
                    ""close_window"":true
                },
                ""customer"":null,
                ""delivery"":null,
                ""shopping_cart"":null,
                ""checkout_options"": null,
                ""custom_fields"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }

        [TestMethod]
        public void Order_CreateRedirect_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateRedirect("orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"));

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);

            Assert.AreEqual(OrderType.Redirect, order.Type);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
        }

        [TestMethod]
        public void Order_CreateDirectiDEAL_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateDirectIdeal("3151", "orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"));

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.GatewayId);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.GatewayInfo);
            Assert.IsNotNull(order.GatewayInfo.IssuerId);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);

            Assert.AreEqual(OrderType.Direct, order.Type);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("iDEAL", order.GatewayId);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual("3151", order.GatewayInfo.IssuerId);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
        }

        [TestMethod]
        public void Order_CreateDirectBankTransfer_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateDirectBankTransfer("orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"));

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.GatewayId);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNull(order.GatewayInfo);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);

            Assert.AreEqual(OrderType.Direct, order.Type);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("BANKTRANS", order.GatewayId);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
        }

        [TestMethod]
        public void Order_CreateRecurring_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateRecurring("recurringid", "orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"));

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.RecurringId);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);

            Assert.AreEqual(OrderType.Direct, order.Type);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("recurringid", order.RecurringId);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
        }

        [TestMethod]
        public void Order_CreateDirectPayAfterDelivery_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateDirectPayAfterDeliveryOrder("orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
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
                new Customer
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

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.GatewayId);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.GatewayInfo);
            Assert.IsNotNull(order.GatewayInfo.Birthday);
            Assert.IsNotNull(order.GatewayInfo.BankAccount);
            Assert.IsNotNull(order.GatewayInfo.Phone);
            Assert.IsNotNull(order.GatewayInfo.Email);
            Assert.IsNotNull(order.GatewayInfo.Referrer);
            Assert.IsNotNull(order.GatewayInfo.UserAgent);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);
            Assert.IsNotNull(order.ShoppingCart);
            Assert.IsNotNull(order.ShoppingCart.Items);
            Assert.IsNotNull(order.ShoppingCart.Items[0]);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Name);
            Assert.IsNotNull(order.ShoppingCart.Items[0].UnitPrice);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Quantity);
            Assert.IsNotNull(order.CheckoutOptions.TaxTables.DefaultTaxTable);
            Assert.IsNotNull(order.Customer);
            Assert.IsNotNull(order.Customer.FirstName);
            Assert.IsNotNull(order.Customer.LastName);
            Assert.IsNotNull(order.Customer.Address1);
            Assert.IsNotNull(order.Customer.HouseNumber);
            Assert.IsNotNull(order.Customer.City);
            Assert.IsNotNull(order.Customer.Country);


            Assert.AreEqual(OrderType.Direct, order.Type);
            Assert.AreEqual("PAYAFTER", order.GatewayId);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(new DateTime(1986, 8, 31), order.GatewayInfo.Birthday);
            Assert.AreEqual("NL39 RABO 0300 0652 64", order.GatewayInfo.BankAccount);
            Assert.AreEqual("+31 (0)20 8500 500", order.GatewayInfo.Phone);
            Assert.AreEqual("test@multisafepay.com", order.GatewayInfo.Email);
            Assert.AreEqual("referrer", order.GatewayInfo.Referrer);
            Assert.AreEqual("useragent", order.GatewayInfo.UserAgent);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
            Assert.AreEqual("Test Product", order.ShoppingCart.Items[0].Name);
            Assert.AreEqual(10, order.ShoppingCart.Items[0].UnitPrice);
            Assert.AreEqual(2, order.ShoppingCart.Items[0].Quantity);
            Assert.AreEqual("Default", order.CheckoutOptions.TaxTables.DefaultTaxTable.Name);
            Assert.AreEqual(0.21, order.CheckoutOptions.TaxTables.DefaultTaxTable.Rules[0].Rate);
            Assert.AreEqual("John", order.Customer.FirstName);
            Assert.AreEqual("Doe", order.Customer.LastName);
            Assert.AreEqual("Kraanspoor", order.Customer.Address1);
            Assert.AreEqual("39", order.Customer.HouseNumber);
            Assert.AreEqual("Amsterdam", order.Customer.City);
            Assert.AreEqual("NL", order.Customer.Country);
        }

        [TestMethod]
        public void Order_CreateRedirectPayAfterDelivery_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateRedirectPayAfterDeliveryOrder("orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"),
                GatewayInfo.PayAfterDelivery(new DateTime(1986, 08, 31), "NL39 RABO 0300 0652 64", "+31 (0)20 8500 500", "test@multisafepay.com", "referrer", "useragent"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
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
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    HouseNumber = "39",
                    Address1 = "Kraanspoor",
                    City = "Amsterdam",
                    Country = "NL",
                    PostCode = "1033SC"
                });

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNotNull(order.GatewayId);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.Description);
            Assert.IsNotNull(order.GatewayInfo);
            Assert.IsNotNull(order.GatewayInfo.Birthday);
            Assert.IsNotNull(order.GatewayInfo.BankAccount);
            Assert.IsNotNull(order.GatewayInfo.Phone);
            Assert.IsNotNull(order.GatewayInfo.Email);
            Assert.IsNotNull(order.GatewayInfo.Referrer);
            Assert.IsNotNull(order.GatewayInfo.UserAgent);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);
            Assert.IsNotNull(order.ShoppingCart);
            Assert.IsNotNull(order.ShoppingCart.Items);
            Assert.IsNotNull(order.ShoppingCart.Items[0]);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Name);
            Assert.IsNotNull(order.ShoppingCart.Items[0].UnitPrice);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Quantity);
            Assert.IsNotNull(order.Customer);
            Assert.IsNotNull(order.Customer.FirstName);
            Assert.IsNotNull(order.Customer.LastName);
            Assert.IsNotNull(order.Customer.Address1);
            Assert.IsNotNull(order.Customer.HouseNumber);
            Assert.IsNotNull(order.Customer.City);
            Assert.IsNotNull(order.Customer.Country);


            Assert.AreEqual(OrderType.Redirect, order.Type);
            Assert.AreEqual("PAYAFTER", order.GatewayId);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual(new DateTime(1986, 8, 31), order.GatewayInfo.Birthday);
            Assert.AreEqual("NL39 RABO 0300 0652 64", order.GatewayInfo.BankAccount);
            Assert.AreEqual("+31 (0)20 8500 500", order.GatewayInfo.Phone);
            Assert.AreEqual("test@multisafepay.com", order.GatewayInfo.Email);
            Assert.AreEqual("referrer", order.GatewayInfo.Referrer);
            Assert.AreEqual("useragent", order.GatewayInfo.UserAgent);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
            Assert.AreEqual("Test Product", order.ShoppingCart.Items[0].Name);
            Assert.AreEqual(10, order.ShoppingCart.Items[0].UnitPrice);
            Assert.AreEqual(2, order.ShoppingCart.Items[0].Quantity);
            Assert.AreEqual("John", order.Customer.FirstName);
            Assert.AreEqual("Doe", order.Customer.LastName);
            Assert.AreEqual("Kraanspoor", order.Customer.Address1);
            Assert.AreEqual("39", order.Customer.HouseNumber);
            Assert.AreEqual("Amsterdam", order.Customer.City);
            Assert.AreEqual("NL", order.Customer.Country);
        }

        [TestMethod]
        public void Order_CreateFastCheckout_SetsRequiredProperties()
        {
            // Act
            var order = OrderRequest.CreateFastCheckoutOrder("orderid", "description", 1000, "EUR",
                new PaymentOptions("notificationUrl", "successRedirectUrl", "cancelRedirectUrl"),
                new ShoppingCart
                {
                    Items = new[]
                    {
                        new ShoppingCartItem("Test Product", 10, 2, "EUR"),
                    }
                },
                new CheckoutOptions()
                {
                    ShippingMethods = new ShippingMethods()
                    {
                        FlatRateShippingMethods = new []
                        {
                            new ShippingMethod("flatrate", 10, "EUR"), 
                        },
                        Pickup = new ShippingMethod("pickup", 10, "EUR")
                    },
                });

            // Assert
            Assert.IsNotNull(order.Type);
            Assert.IsNull(order.GatewayId);
            Assert.IsNotNull(order.OrderId);
            Assert.IsNotNull(order.CurrencyCode);
            Assert.IsNotNull(order.AmountInCents);
            Assert.IsNotNull(order.Description);
            Assert.IsNull(order.GatewayInfo);
            Assert.IsNotNull(order.PaymentOptions);
            Assert.IsNotNull(order.PaymentOptions.NotificationUrl);
            Assert.IsNotNull(order.PaymentOptions.SuccessRedirectUrl);
            Assert.IsNotNull(order.PaymentOptions.CancelRedirectUrl);
            Assert.IsNotNull(order.ShoppingCart);
            Assert.IsNotNull(order.ShoppingCart.Items);
            Assert.IsNotNull(order.ShoppingCart.Items[0]);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Name);
            Assert.IsNotNull(order.ShoppingCart.Items[0].UnitPrice);
            Assert.IsNotNull(order.ShoppingCart.Items[0].Quantity);
            Assert.IsNotNull(order.CheckoutOptions);
            Assert.IsNotNull(order.CheckoutOptions.ShippingMethods);
            Assert.IsNotNull(order.CheckoutOptions.ShippingMethods.FlatRateShippingMethods);
            Assert.IsNotNull(order.CheckoutOptions.ShippingMethods.Pickup);


            Assert.AreEqual(OrderType.FastCheckout, order.Type);
            Assert.AreEqual("orderid", order.OrderId);
            Assert.AreEqual("EUR", order.CurrencyCode);
            Assert.AreEqual(1000, order.AmountInCents);
            Assert.AreEqual("description", order.Description);
            Assert.AreEqual("notificationUrl", order.PaymentOptions.NotificationUrl);
            Assert.AreEqual("successRedirectUrl", order.PaymentOptions.SuccessRedirectUrl);
            Assert.AreEqual("cancelRedirectUrl", order.PaymentOptions.CancelRedirectUrl);
            Assert.AreEqual("Test Product", order.ShoppingCart.Items[0].Name);
            Assert.AreEqual(10, order.ShoppingCart.Items[0].UnitPrice);
            Assert.AreEqual(2, order.ShoppingCart.Items[0].Quantity);
            Assert.AreEqual("flatrate", order.CheckoutOptions.ShippingMethods.FlatRateShippingMethods[0].Name);
            Assert.AreEqual(10, order.CheckoutOptions.ShippingMethods.FlatRateShippingMethods[0].Price);
            Assert.AreEqual("EUR", order.CheckoutOptions.ShippingMethods.FlatRateShippingMethods[0].CurrencyCode);
            Assert.AreEqual("pickup", order.CheckoutOptions.ShippingMethods.Pickup.Name);
            Assert.AreEqual(10, order.CheckoutOptions.ShippingMethods.Pickup.Price);
            Assert.AreEqual("EUR", order.CheckoutOptions.ShippingMethods.Pickup.CurrencyCode);
        }
    }
}
