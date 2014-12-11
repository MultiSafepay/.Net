using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.UnitTests
{
    /// <summary>
    /// Tests that the UrlProvider returns the correct resource urls for each resource.
    /// Also checks that correct resources urls are returned whether or not a trailing slash is specified.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UrlProviderTests
    {
        private readonly string[] _baseUrls = { "https://api.multisafepay.com/", "https://api.multisafepay.com" };

        [TestMethod]
        public void GatewaysUrl_Default()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);

                // Act
                var url = provider.GatewaysUrl();

                // Assert
                Assert.AreEqual(String.Format("{0}/gateways", baseUrl.TrimTrailingSlash()), url);
            }
        }
        [TestMethod]
        public void GatewaysUrl_WithFilters()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);

                // Act
                var url = provider.GatewaysUrl("NL", "EUR", 100);

                // Assert
                Assert.AreEqual(String.Format("{0}/gateways?country=NL&currency=EUR&amount=100", baseUrl.TrimTrailingSlash()), url);
            }
        }

        [TestMethod]
        public void GatewaysUrl_Default_Locale()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl, "ES");

                // Act
                var url = provider.GatewaysUrl();

                // Assert
                Assert.AreEqual(String.Format("{0}/gateways?locale=es", baseUrl.TrimTrailingSlash()), url);
            }
        }

        [TestMethod]
        public void GatewaysUrl_WithFilters_Locale()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl, "ES");

                // Act
                var url = provider.GatewaysUrl("NL", "EUR", 100);

                // Assert
                Assert.AreEqual(String.Format("{0}/gateways?country=NL&currency=EUR&amount=100&locale=es", baseUrl.TrimTrailingSlash()), url);
            }
        }

        [TestMethod]
        public void GatewayUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string name = " test";

                // Act
                var url = provider.GatewayUrl(name);

                // Assert
                Assert.AreEqual(String.Format("{0}/gateways/{1}", baseUrl.TrimTrailingSlash(), name), url);
            }
        }

        [TestMethod]
        public void IssuersUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string name = " test";

                // Act
                var url = provider.IssuersUrl(name);

                // Assert
                Assert.AreEqual(String.Format("{0}/issuers/{1}", baseUrl.TrimTrailingSlash(), name), url);
            }
        }

        [TestMethod]
        public void OrderUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string orderid = " test";

                // Act
                var url = provider.OrderUrl(orderid);

                // Assert
                Assert.AreEqual(String.Format("{0}/orders/{1}", baseUrl.TrimTrailingSlash(), orderid), url);
            }
        }

        [TestMethod]
        public void TransactionUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string transactionId = " test";

                // Act
                var url = provider.TransactionUrl(transactionId);

                // Assert
                Assert.AreEqual(String.Format("{0}/transactions/{1}", baseUrl.TrimTrailingSlash(), transactionId), url);
            }
        }

        [TestMethod]
        public void PaymentLinkUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string orderId = " test";

                // Act
                var url = provider.PaymentLinkUrl(orderId);

                // Assert
                Assert.AreEqual(String.Format("{0}/orders/{1}/paymentlink", baseUrl.TrimTrailingSlash(), orderId), url);
            }
        }

        [TestMethod]
        public void OrdersUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);

                // Act
                var url = provider.OrdersUrl();

                // Assert
                Assert.AreEqual(String.Format("{0}/orders", baseUrl.TrimTrailingSlash()), url);
            }
        }

        [TestMethod]
        public void OrderRefundsUrl()
        {
            foreach (var baseUrl in _baseUrls)
            {
                // Arrange
                var provider = new UrlProvider(baseUrl);
                const string orderId = " test";

                // Act
                var url = provider.OrderRefundsUrl(orderId);

                // Assert
                Assert.AreEqual(String.Format("{0}/orders/{1}/refunds", baseUrl.TrimTrailingSlash(), orderId), url);
            }
        }
    }

    [ExcludeFromCodeCoverage]
    public static class StringExtension
    {
        public static string TrimTrailingSlash(this string input)
        {
            if (input.EndsWith("/"))
            {
                return input.Substring(0, input.Length - 1);
            }
            return input;
        }
    }
}
