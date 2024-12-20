# OAuth
(*OAuth*)

## Overview

Use the OAuth API to enable your ecommerce server to make API calls on behalf of a Bolt logged-in shopper.
<https://help.bolt.com/products/accounts/direct-api/oauth-guide/>

### Available Operations

* [GetToken](#gettoken) - Get OAuth token

## GetToken

Retrieve a new or refresh an existing OAuth token.

### Example Usage

```csharp
using Boltpay.SDK;
using Boltpay.SDK.Models.Requests;
using Boltpay.SDK.Models.Components;
using System.Collections.Generic;

var sdk = new BoltSDK();

var res = await sdk.OAuth.GetTokenAsync(
    tokenRequest: TokenRequest.CreateAuthorizationCodeRequest(
        new AuthorizationCodeRequest() {
            GrantType = Boltpay.SDK.Models.Components.GrantType.AuthorizationCode,
            Code = "7GSjMRSHs6Ak7C_zvVW6P2IhZOHxMK7HZKW1fMX85ms",
            ClientId = "8fd9diIy59sj.IraJdeIgmdsO.fd233434fg2c616cgo932aa6e1e4fc627a9385045gr395222a127gi93c595rg4",
            ClientSecret = "23ee7ec7301779eaff451d7c6f6cba322499e3c0ec752f800c72a8f99217e3a8",
            Scope = new List<Scope>() {
                Boltpay.SDK.Models.Components.Scope.BoltAccountView,
            },
            State = "xyzABC123",
        }
    ),
    xMerchantClientId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                                            | Type                                                                                                                                                                                                                                                                                                                 | Required                                                                                                                                                                                                                                                                                                             | Description                                                                                                                                                                                                                                                                                                          |
| -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `TokenRequest`                                                                                                                                                                                                                                                                                                       | [TokenRequest](../../Models/Components/TokenRequest.md)                                                                                                                                                                                                                                                              | :heavy_check_mark:                                                                                                                                                                                                                                                                                                   | N/A                                                                                                                                                                                                                                                                                                                  |
| `XMerchantClientId`                                                                                                                                                                                                                                                                                                  | *string*                                                                                                                                                                                                                                                                                                             | :heavy_minus_sign:                                                                                                                                                                                                                                                                                                   | A unique identifier for a shopper's device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics. |

### Response

**[OauthGetTokenResponse](../../Models/Requests/OauthGetTokenResponse.md)**

### Errors

| Error Type                             | Status Code                            | Content Type                           |
| -------------------------------------- | -------------------------------------- | -------------------------------------- |
| Boltpay.SDK.Models.Errors.Error        | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.FieldError   | 4XX                                    | application/json                       |
| Boltpay.SDK.Models.Errors.SDKException | 5XX                                    | \*/\*                                  |