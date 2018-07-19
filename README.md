# .Net
A .Net wrapper for the MultiSafepay payments API. Provides support for all payment methods, Pay After Delivery and Fast Checkout.

## Environments
Test API - https://testapi.multisafepay.com/v1/json/

Live API - https://api.multisafepay.com/v1/json/

## Api Reference
https://www.multisafepay.com/documentation/doc/API-Reference/


## Available on NuGet.
https://www.nuget.org/packages/MultiSafepay/

```
Install-Package MultiSafepay
```

#### Example
```
var client = new MultiSafepayClient("API_KEY", "https://testapi.multisafepay.com/v1/json/");
var gateways = client.GetGateways(null, "EUR");
```

#### Example - Order CustomOrder
```
var client = new MultiSafepayClient("API_KEY", "https://testapi.multisafepay.com/v1/json/");
var order = new Order
            {
                Type = OrderType.Redirect,
                OrderId = Guid.NewGuid().ToString(),
                GatewayId = "IDEAL",
                AmountInCents = 1066,
                CurrencyCode = "EUR",
                Description = ".Net wrapper test",
                PaymentOptions = new PaymentOptions("http://example.com/notify", "http://example.com/success", "http://example.com/failed"),
                Customer = new Customer()
                {
                    FirstName = "First Name",
                    LastName = "Last Name",
                    Country = "NL",
                    Locale = "EN",
                    Email = "test@multisafepay.com"
                }
            };

var result = client.CustomOrder(order);

```