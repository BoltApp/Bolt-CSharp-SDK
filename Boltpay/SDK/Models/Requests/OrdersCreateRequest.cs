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
    
    public class OrdersCreateRequest
    {

        /// <summary>
        /// The publicly viewable identifier used to identify a merchant division.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=X-Publishable-Key")]
        public string XPublishableKey { get; set; } = default!;

        /// <summary>
        /// A unique identifier for a shopper&apos;s device, generated by Bolt. This header is required for proper attribution of this operation to your analytics reports. Omitting this header may result in incorrect statistics.
        /// </summary>
        [SpeakeasyMetadata("header:style=simple,explode=false,name=X-Merchant-Client-Id")]
        public string XMerchantClientId { get; set; } = default!;

        [SpeakeasyMetadata("request:mediaType=application/json")]
        public Order Order { get; set; } = default!;
    }
}