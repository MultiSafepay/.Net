using System;
using System.Linq;
using System.Web;

namespace MultiSafepay.Model
{
    public static class NotificationUrl
    {
        public static string ParseOrderId(string notificationUrl)
        {

            var queryComponents = HttpUtility.ParseQueryString(notificationUrl);
            return queryComponents.Keys != null && queryComponents.Keys.Contains("transactionid") ? null : null;
        }
    }
}
