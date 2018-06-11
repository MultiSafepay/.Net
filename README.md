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
var client = new MultiSafepayClient("API_KEY", "https://api.multisafepay.com/v1/json/");
var gateways = client.GetGateways(null, "EUR");
```