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
    using Boltpay.SDK.Utils;
    using Newtonsoft.Json;
    
    /// <summary>
    /// An account&apos;s identifying information.
    /// </summary>
    public class Profile
    {

        /// <summary>
        /// The given name of the person associated with this profile.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// The last name of the person associated with this profile.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; } = default!;

        /// <summary>
        /// The email address asscoiated with this profile.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = default!;

        /// <summary>
        /// The phone number associated with this profile.
        /// </summary>
        [JsonProperty("phone")]
        public string? Phone { get; set; }
    }
}