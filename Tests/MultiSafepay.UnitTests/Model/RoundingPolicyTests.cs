using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
 
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RoundingPolicyTests
    {
        [TestMethod]
        public void Weight_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var roundingPolicy = new RoundingPolicy();

            // Act
            var serializedObject = JsonConvert.SerializeObject(roundingPolicy);

            // Assert
            Assert.AreEqual(@"{
				""mode"": ""UP"",
				""rule"": ""PER_ITEM""
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
