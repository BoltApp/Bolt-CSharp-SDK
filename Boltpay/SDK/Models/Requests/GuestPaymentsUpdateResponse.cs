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
    using Boltpay.SDK.Models.Components;
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    
    public class GuestPaymentsUpdateResponse
    {

        [JsonProperty("-")]
        public HTTPMetadata HttpMeta { get; set; } = default!;

        /// <summary>
        /// The pending payment was successfully updated
        /// </summary>
        public PaymentResponse? PaymentResponse { get; set; }

        public PaymentResponseFinalized? GetPaymentResponseFinalized()
        {
            return PaymentResponse != null ? PaymentResponse.PaymentResponseFinalized : null;
        }

        public PaymentResponsePending? GetPaymentResponsePending()
        {
            return PaymentResponse != null ? PaymentResponse.PaymentResponsePending : null;
        }
    }
}