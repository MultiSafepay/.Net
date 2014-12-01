using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var order = new OrderRequest(PaymentFlow.Redirect, null, 1000, null, 
                new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"));

            // Act
            var serializedObject = JsonConvert.SerializeObject(order);

            // Assert
            Assert.AreEqual(@"{
	            ""type"": ""redirect"",
	            ""id"": null,
	            ""currency"": null,
	            ""amount"": 1000,
	            ""description"": null,
	            ""var1"": null,
	            ""var2"": null,
	            ""var3"": null,
	            ""items"": null,
	            ""manual"": null,
	            ""days_active"": null,
                ""payment_options"": {
                    ""notification_url"": ""http://example.com/notify"",
                    ""redirect_url"": ""http://example.com/success"",
                    ""cancel_url"": ""http://example.com/failed"",
                    ""close_window"":true
                }
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
