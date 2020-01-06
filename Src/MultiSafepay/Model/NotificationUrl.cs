using System;
using System.Linq;
using System.Web;

namespace MultiSafepay.Model
{
    public static class NotificationUrl
    {
        public static string ParseOrderId(string notificationUrl)
        {
            var uri = new Uri(notificationUrl);
            var queryComponents = HttpUtility.ParseQueryString(uri.Query);
            var value = queryComponents.Get("transactionid");
            return value == string.Empty ? null : value;
        }
    }
}
