using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class OrderTests
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
	            ""id"": null,
	            ""currency"": null,
	            ""amount"": 1000,
                ""gateway"": null,
	            ""description"": null,
	            ""var1"": null,
	            ""var2"": null,
	            ""var3"": null,
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
                ""shopping_cart"":null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
