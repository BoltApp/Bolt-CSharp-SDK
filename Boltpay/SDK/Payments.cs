//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK
{
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Models.Errors;
    using Boltpay.SDK.Utils;
    using System;

    public interface IPayments
    {
        public ILoggedIn LoggedIn { get; }
        public IGuest Guest { get; }
    }

    public class Payments: IPayments
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.3.0";
        private const string _sdkGenVersion = "2.438.15";
        private const string _openapiDocVersion = "3.2.3";
        private const string _userAgent = "speakeasy-sdk/csharp 0.3.0 2.438.15 3.2.3 Boltpay.SDK";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Boltpay.SDK.Models.Components.Security>? _securitySource;
        public ILoggedIn LoggedIn { get; private set; }
        public IGuest Guest { get; private set; }

        public Payments(ISpeakeasyHttpClient client, Func<Boltpay.SDK.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
            LoggedIn = new LoggedIn(_client, _securitySource, _serverUrl, SDKConfiguration);
            Guest = new Guest(_client, _securitySource, _serverUrl, SDKConfiguration);
        }
    }
}