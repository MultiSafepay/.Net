using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    public class ShoppingCartItemTests
    {
        [TestMethod]
        public void ShoppingCartItem_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var shoppingCartItem = new ShoppingCartItem();

            // Act
            var serializedObject = JsonConvert.SerializeObject(shoppingCartItem);

            // Assert
            Assert.AreEqual(@"{
				""name"": null,
				""description"": null,
				""unit_price"": 0,
				""quantity"": 0,
				""merchant_item_id"": null,
				""tax_table_selector"": null,
				""weight"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
