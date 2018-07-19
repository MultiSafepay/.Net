using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class OrderResponseTests
    {
        [TestMethod]
        public void Order_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var order = new OrderResponse();

            // Act
            var serializedObject = JsonConvert.SerializeObject(order);

            // Assert
            Assert.AreEqual(@"{
            ""transaction_id"": null,
            ""created"": null,
            ""modified"": null,
            ""order_id"": null,
            ""currency"": null,
            ""amount"": 0,
            ""amount_refunded"": 0.0,
            ""status"": null,
            ""financial_status"": null,
            ""fastcheckout"": null,
            ""gateway"": 0,
            ""description"": null,
            ""var1"": null,
            ""var2"": null,
            ""var3"": null,
            ""items"": null,
            ""customer"": null,
            ""delivery"": null,
            ""payment_details"": null,
            ""cancel_url"": null,
            ""shopping_cart"": null,
            ""costs"": null,
            ""payment_url"": null,
            ""html_form"": null,
            ""custom_info"": null
            }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
