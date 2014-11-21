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
            var order = new OrderRequest();

            // Act
            var serializedObject = JsonConvert.SerializeObject(order);

            // Assert
            Assert.AreEqual(@"{
	            ""type"": null,
	            ""id"": null,
	            ""currency"": null,
	            ""amount"": null,
	            ""description"": null,
	            ""var1"": null,
	            ""var2"": null,
	            ""var3"": null,
	            ""items"": null,
	            ""manual"": null,
	            ""days_active"": null
	        }".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
