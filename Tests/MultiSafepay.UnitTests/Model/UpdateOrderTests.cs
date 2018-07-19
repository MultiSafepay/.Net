using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UpdateOrderTests
    {
        [TestMethod]
        public void UpdateOrder_SerializeDefaultValues_PropertyNamesAsExpected()
        {
            // Arrange
            var orderStatus = new UpdateOrder();

            // Act
            var serializedObject = JsonConvert.SerializeObject(orderStatus);

            // Assert
            Assert.AreEqual(@"{
		                        ""invoice_id"": null,
                                ""invoice_url"": null,
                                ""type"": null,
                                ""currency"": null,
                                ""description"": null,
                                ""tracktrace_code"": null,
                                ""tracktrace_url"": null,
                                ""carrier"": null,
                                ""po_number"": null,
                                ""reason"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }

        [TestMethod]
        public void UpdateOrder_SerializeAllValues_PropertyNamesAsExpected()
        {
            // Arrange
            var orderStatus = new UpdateOrder()
            {
                Amount = 1,
                ShippingDate = new DateTime(1990, 1, 1)
            };

            // Act
            var serializedObject = JsonConvert.SerializeObject(orderStatus);

            // Assert
            Assert.AreEqual(@"{
		                        ""invoice_id"": null,
                                ""invoice_url"": null,
                                ""type"": null,
                                ""amount"": 1,
                                ""currency"": null,
                                ""description"": null,
                                ""tracktrace_code"": null,
                                ""tracktrace_url"": null,
                                ""carrier"": null,
                                ""ship_date"": ""1990-01-01T00:00:00"",
                                ""po_number"": null,
                                ""reason"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
