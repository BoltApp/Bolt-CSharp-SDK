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
    using Boltpay.SDK.Utils.Retries;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;


    public enum ServerEnvironment
    {
        [JsonProperty("api")]
        Api,
        [JsonProperty("api-sandbox")]
        ApiSandbox,
    }

    public static class ServerEnvironmentExtension
    {
        public static string Value(this ServerEnvironment value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ServerEnvironment ToEnum(this string value)
        {
            foreach(var field in typeof(ServerEnvironment).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is ServerEnvironment)
                    {
                        return (ServerEnvironment)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum ServerEnvironment");
        }
    }

    /// <summary>
    /// Bolt API Reference: A comprehensive Bolt API reference for interacting with Transactions, Orders, Product Catalog, Configuration, Testing, and much more.
    /// </summary>
    public interface IBoltSDK
    {

        /// <summary>
        /// Account endpoints allow you to view and manage shoppers&apos; accounts. For example,<br/>
        /// 
        /// <remarks>
        /// you can add or remove addresses and payment information.<br/>
        /// 
        /// </remarks>
        /// </summary>
        public IAccount Account { get; }
        public IPayments Payments { get; }

        /// <summary>
        /// Use this endpoint to retrieve an OAuth token. Use the token to allow your ecommerce server to make calls to the Account<br/>
        /// 
        /// <remarks>
        /// endpoint and create a one-click checkout experience for shoppers.<br/>
        /// 
        /// </remarks>
        /// 
        /// <see>https://help.bolt.com/products/accounts/direct-api/oauth-guide/}</see>
        /// </summary>
        public IOAuth OAuth { get; }

        /// <summary>
        /// Use the Orders API to create and manage orders, including orders that have been placed outside the Bolt ecosystem.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        public IOrders Orders { get; }

        /// <summary>
        /// Endpoints that allow you to generate and retrieve test data to verify certain<br/>
        /// 
        /// <remarks>
        /// flows in non-production environments.<br/>
        /// 
        /// </remarks>
        /// </summary>
        public ITesting Testing { get; }
    }

    public class SDKConfig
    {
        /// <summary>
        /// List of server URLs available to the SDK.
        /// </summary>
        public static readonly string[] ServerList = {
            "https://{environment}.bolt.com/v3",
        };

        public string ServerUrl = "";
        public int ServerIndex = 0;
        public List<Dictionary<string, string>> ServerDefaults = new List<Dictionary<string, string>>();
        public SDKHooks Hooks = new SDKHooks();
        public RetryConfig? RetryConfig = null;

        public string GetTemplatedServerUrl()
        {
            if (!String.IsNullOrEmpty(this.ServerUrl))
            {
                return Utilities.TemplateUrl(Utilities.RemoveSuffix(this.ServerUrl, "/"), new Dictionary<string, string>());
            }
            return Utilities.TemplateUrl(SDKConfig.ServerList[this.ServerIndex], this.ServerDefaults[this.ServerIndex]);
        }

        public ISpeakeasyHttpClient InitHooks(ISpeakeasyHttpClient client)
        {
            string preHooksUrl = GetTemplatedServerUrl();
            var (postHooksUrl, postHooksClient) = this.Hooks.SDKInit(preHooksUrl, client);
            if (preHooksUrl != postHooksUrl)
            {
                this.ServerUrl = postHooksUrl;
            }
            return postHooksClient;
        }
    }

    /// <summary>
    /// Bolt API Reference: A comprehensive Bolt API reference for interacting with Transactions, Orders, Product Catalog, Configuration, Testing, and much more.
    /// </summary>
    public class BoltSDK: IBoltSDK
    {
        public SDKConfig SDKConfiguration { get; private set; }

        private const string _language = "csharp";
        private const string _sdkVersion = "0.0.2";
        private const string _sdkGenVersion = "2.370.2";
        private const string _openapiDocVersion = "3.1.0";
        private const string _userAgent = "speakeasy-sdk/csharp 0.0.2 2.370.2 3.1.0 Boltpay.SDK";
        private string _serverUrl = "";
        private int _serverIndex = 0;
        private ISpeakeasyHttpClient _client;
        private Func<Security>? _securitySource;
        public IAccount Account { get; private set; }
        public IPayments Payments { get; private set; }
        public IOAuth OAuth { get; private set; }
        public IOrders Orders { get; private set; }
        public ITesting Testing { get; private set; }

        public BoltSDK(Security? security = null, Func<Security>? securitySource = null, int? serverIndex = null, ServerEnvironment? environment = null, string? serverUrl = null, Dictionary<string, string>? urlParams = null, ISpeakeasyHttpClient? client = null, RetryConfig? retryConfig = null)
        {
            if (serverIndex != null)
            {
                if (serverIndex.Value < 0 || serverIndex.Value >= SDKConfig.ServerList.Length)
                {
                    throw new Exception($"Invalid server index {serverIndex.Value}");
                }
                _serverIndex = serverIndex.Value;
            }

            if (serverUrl != null)
            {
                if (urlParams != null)
                {
                    serverUrl = Utilities.TemplateUrl(serverUrl, urlParams);
                }
                _serverUrl = serverUrl;
            }
            List<Dictionary<string, string>> serverDefaults = new List<Dictionary<string, string>>()
            {
                new Dictionary<string, string>()
                {
                    {"environment", environment == null ? "api-sandbox" : ServerEnvironmentExtension.Value(environment.Value)},
                },
            };

            _client = client ?? new SpeakeasyHttpClient();

            if(securitySource != null)
            {
                _securitySource = securitySource;
            }
            else if(security != null)
            {
                _securitySource = () => security;
            }

            SDKConfiguration = new SDKConfig()
            {
                ServerDefaults = serverDefaults,
                ServerIndex = _serverIndex,
                ServerUrl = _serverUrl,
                RetryConfig = retryConfig
            };

            _client = SDKConfiguration.InitHooks(_client);


            Account = new Account(_client, _securitySource, _serverUrl, SDKConfiguration);


            Payments = new Payments(_client, _securitySource, _serverUrl, SDKConfiguration);


            OAuth = new OAuth(_client, _securitySource, _serverUrl, SDKConfiguration);


            Orders = new Orders(_client, _securitySource, _serverUrl, SDKConfiguration);


            Testing = new Testing(_client, _securitySource, _serverUrl, SDKConfiguration);
        }
    }
}