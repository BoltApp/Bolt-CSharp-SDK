//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
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
    
    public class PaymentMethodReference
    {

        [JsonProperty(".tag")]
        public PaymentMethodReferenceTag DotTag { get; set; } = default!;

        /// <summary>
        /// Payment ID of the saved Bolt Payment method.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = default!;
    }
}