//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Components
{
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    public class Account
    {

        /// <summary>
        /// A list of addresses associated with this account.
        /// </summary>
        [JsonProperty("addresses")]
        public List<AddressListing> Addresses { get; set; } = default!;

        /// <summary>
        /// A list of payment methods associated with this account.
        /// </summary>
        [JsonProperty("payment_methods")]
        public List<PaymentMethod> PaymentMethods { get; set; } = default!;

        [JsonProperty("profile")]
        public Profile? Profile { get; set; }
    }
}