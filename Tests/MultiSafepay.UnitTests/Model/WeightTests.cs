using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WeightTests
    {
        [TestMethod]
        public void Weight_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var weight = new Weight();

            // Act
            var serializedObject = JsonConvert.SerializeObject(weight);

            // Assert
            Assert.AreEqual(@"{
				""unit"": null,
				""value"": 0.0
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
