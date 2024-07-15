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
    
    public class PaymentMethodKlarnaPaynow
    {

        [JsonProperty(".tag")]
        public PaymentMethodKlarnaPaynowTag DotTag { get; set; } = default!;

        /// <summary>
        /// Return URL to return to after payment completion in Klarna.
        /// </summary>
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; } = default!;
    }
}