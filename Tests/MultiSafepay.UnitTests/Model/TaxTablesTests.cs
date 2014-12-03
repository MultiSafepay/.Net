using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiSafepay.Model;
using Newtonsoft.Json;

namespace MultiSafepay.UnitTests.Model
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TaxTablesTests
    {
        [TestMethod]
        public void TaxTables_Serialize_PropertyNamesAsExpected()
        {
            // Arrange
            var taxTables = new TaxTables();

            // Act
            var serializedObject = JsonConvert.SerializeObject(taxTables);

            // Assert
            Assert.AreEqual(@"{
				""default"": null,
				""alternate"": null
			}".RemoveWhiteSpace(), serializedObject.RemoveWhiteSpace());
        }
    }
}
