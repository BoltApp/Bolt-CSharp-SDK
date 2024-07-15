//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK
{
    using Boltpay.SDK.Hooks;
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Models.Errors;
    using Boltpay.SDK.Models.Requests;
    using Boltpay.SDK.Utils.Retries;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Account endpoints allow you to view and manage shoppers&apos; accounts. For example,<br/>
    /// 
    /// <remarks>
    /// you can add or remove addresses and payment information.<br/>
    /// 
    /// </remarks>
    /// </summary>
    public interface IAccount
    {

        /// <summary>
        /// Retrieve account details
        /// 
        /// <remarks>
        /// Retrieve a shopper&apos;s account details, such as addresses and payment information
        /// </remarks>
        /// </summary>
        Task<AccountGetResponse> GetDetailsAsync(string xPublishableKey, string xMerchantClientId);

        /// <summary>
        /// Add an address
        /// 
        /// <remarks>
        /// Add an address to the shopper&apos;s account
        /// </remarks>
        /// </summary>
        Task<AccountAddressCreateResponse> AddAddressAsync(string xPublishableKey, string xMerchantClientId, AddressListingInput addressListing);

        /// <summary>
        /// Edit an existing address
        /// 
        /// <remarks>
        /// Edit an existing address on the shopper&apos;s account. This does not edit addresses<br/>
        /// that are already associated with other resources, such as transactions or<br/>
        /// shipments.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<AccountAddressEditResponse> UpdateAddressAsync(string xPublishableKey, string xMerchantClientId, string id, AddressListingInput addressListing);

        /// <summary>
        /// Delete an existing address
        /// 
        /// <remarks>
        /// Delete an existing address. Deleting an address does not invalidate transactions or<br/>
        /// shipments that are associated with it.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<AccountAddressDeleteResponse> DeleteAddressAsync(string xPublishableKey, string xMerchantClientId, string id);

        /// <summary>
        /// Add a payment method to a shopper&apos;s Bolt account Wallet.
        /// 
        /// <remarks>
        /// Add a payment method to a shopper&apos;s Bolt account Wallet. For security purposes, this request must come from<br/>
        /// your backend because authentication requires the use of your private key.&lt;br /&gt;<br/>
        /// **Note**: Before using this API, the credit card details must be tokenized using Bolt&apos;s JavaScript library function,<br/>
        /// which is documented in <a href="https://help.bolt.com/developers/references/bolt-tokenizer">Install the Bolt Tokenizer</a>.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<AccountAddPaymentMethodResponse> AddPaymentMethodAsync(string xPublishableKey, string xMerchantClientId, PaymentMethodInput paymentMethod);

        /// <summary>
        /// Delete an existing payment method
        /// 
        /// <remarks>
        /// Delete an existing payment method. Deleting a payment method does not invalidate transactions or<br/>
        /// orders that are associated with it.<br/>
        /// 
        /// </remarks>
        /// </summary>
        Task<AccountPaymentMethodDeleteResponse> DeletePaymentMethodAsync(string xPublishableKey, string xMerchantClientId, string id);
    }

    /// <summary>
    /// Account endpoints allow you to view and manage shoppers&apos; accounts. For example,<br/>
    /// 
    /// <remarks>
    /// you can add or remove addresses and payment information.<br/>
    /// 
    /// </remarks>
    /// </summary>
    public class Account: IAccount
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.0.2";
        private const string _sdkGenVersion = "2.370.2";
        private const string _openapiDocVersion = "3.1.0";
        private const string _userAgent = "speakeasy-sdk/csharp 0.0.2 2.370.2 3.1.0 Boltpay.SDK";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Security>? _securitySource;

        public Account(ISpeakeasyHttpClient client, Func<Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<AccountGetResponse> GetDetailsAsync(string xPublishableKey, string xMerchantClientId)
        {
            var request = new AccountGetRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/account";

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountGet", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Models.Components.Account>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new AccountGetResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.Account = obj;
                    return response;
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Response4xx>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountGetResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<AccountAddressCreateResponse> AddAddressAsync(string xPublishableKey, string xMerchantClientId, AddressListingInput addressListing)
        {
            var request = new AccountAddressCreateRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                AddressListing = addressListing,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/account/addresses";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "AddressListing", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountAddressCreate", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<AddressListing>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new AccountAddressCreateResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.AddressListing = obj;
                    return response;
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ResponseAddressError>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountAddressCreateResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<AccountAddressEditResponse> UpdateAddressAsync(string xPublishableKey, string xMerchantClientId, string id, AddressListingInput addressListing)
        {
            var request = new AccountAddressEditRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                Id = id,
                AddressListing = addressListing,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/account/addresses/{id}", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Put, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "AddressListing", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountAddressEdit", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<AddressListing>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new AccountAddressEditResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.AddressListing = obj;
                    return response;
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ResponseAddressError>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountAddressEditResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<AccountAddressDeleteResponse> DeleteAddressAsync(string xPublishableKey, string xMerchantClientId, string id)
        {
            var request = new AccountAddressDeleteRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                Id = id,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/account/addresses/{id}", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountAddressDelete", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Response4xx>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountAddressDeleteResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<AccountAddPaymentMethodResponse> AddPaymentMethodAsync(string xPublishableKey, string xMerchantClientId, PaymentMethodInput paymentMethod)
        {
            var request = new AccountAddPaymentMethodRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                PaymentMethod = paymentMethod,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/account/payment-methods";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            var serializedBody = RequestBodySerializer.Serialize(request, "PaymentMethod", "json", false, false);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountAddPaymentMethod", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<PaymentMethod>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new AccountAddPaymentMethodResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.PaymentMethod = obj;
                    return response;
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ResponsePaymentMethodError>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        case "credit-card-error":
                              throw obj!.CreditCardError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountAddPaymentMethodResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }

        public async Task<AccountPaymentMethodDeleteResponse> DeletePaymentMethodAsync(string xPublishableKey, string xMerchantClientId, string id)
        {
            var request = new AccountPaymentMethodDeleteRequest()
            {
                XPublishableKey = xPublishableKey,
                XMerchantClientId = xMerchantClientId,
                Id = id,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/account/payment-methods/{id}", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Delete, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);
            HeaderSerializer.PopulateHeaders(ref httpRequest, request);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("accountPaymentMethodDelete", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Response4xx>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    switch (obj!.Type.ToString()) {
                        case "error":
                              throw obj!.Error!;
                        case "field-error":
                              throw obj!.FieldError!;
                        default:
                            throw new InvalidOperationException("Unknown error type.");
                    };
                }
                else
                {
                    throw new SDKException("Unknown content type received", httpRequest, httpResponse);
                }
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new SDKException("API error occurred", httpRequest, httpResponse);
            }
            else
            {                
                return new AccountPaymentMethodDeleteResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
        }
    }
}