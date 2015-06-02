using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ShoppingCartItemTests
    {
        [TestMethod]
        public void ShoppingCartItem_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shoppingCartItem = new ShoppingCartItem(null, 0, 0, "EUR");

            // Act
            var serializedObject = JsonConvert.SerializeObject(shoppingCartItem);

            // Assert
            Assert.AreEqual(@"{
				""name"": null,
				""description"": null,
				""unit_price"": 0.0,
                ""currency"": ""EUR"",
				""quantity"": 0,
				""merchant_item_id"": null,
				""tax_table_selector"": null,
				""weight"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
