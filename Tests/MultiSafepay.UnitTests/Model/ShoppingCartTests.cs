using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ShoppingCart_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            // Act
            var serializedObject = JsonConvert.SerializeObject(shoppingCart);

            // Assert
            Assert.AreEqual(@"{
 		        ""items"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
