//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Requests
{
    using Boltpay.SDK.Models.Requests;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    
    public class TestingCreditCardGetRequestBody
    {

        /// <summary>
        /// The expected authorization result when using the generated token for a payment.
        /// </summary>
        [JsonProperty("type")]
        public Type Type { get; set; } = default!;
    }
}