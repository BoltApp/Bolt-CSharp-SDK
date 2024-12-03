//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Models.Requests
{
    using Boltpay.SDK.Utils;
    
    public class AccountPaymentMethodDeleteRequest
    {

        /// <summary>
        /// The publicly shareable identifier used to identify your Bolt merchant division.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=X-Publishable-Key")]
        public string XPublishableKey { get; set; } = default!;

        /// <summary>
        /// The ID of the payment method to delete
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=id")]
        public string Id { get; set; } = default!;

        /// <summary>
        /// A unique identifier for a shopper&apos;s device, generated by Bolt. The value is retrieved with `Bolt.state.merchantClientId` in your frontend context, per-shopper. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=X-Merchant-Client-Id")]
        public string? XMerchantClientId { get; set; }
    }
}