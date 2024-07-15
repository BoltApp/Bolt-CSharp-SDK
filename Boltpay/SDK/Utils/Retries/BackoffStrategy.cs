//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Boltpay.SDK.Utils.Retries
{
    public class BackoffStrategy
    {
        public readonly long InitialIntervalMs;
        public readonly long MaxIntervalMs;
        public readonly long MaxElapsedTimeMs;
        public readonly double BaseFactor;
        public readonly double JitterFactor;

        /// <summary>
        /// Configures the exponential backoff strategy.
        /// </summary>
        /// <remarks>
        /// The duration between consecutive attempts is calculated as follows:
        ///     intervalMs = min(maxIntervalMs, initialIntervalMs*(baseFactor^attempts) +/- r)
        /// where baseFactor (also referred to as "exponent") is the multiplicative factor
        /// and r a random value between 0 and jitterFactor*intervalMs.
        /// </remarks>
        /// <param name="initialIntervalMs">The initial interval in milliseconds.</param>
        /// <param name="maxIntervalMs">The maximum interval in milliseconds.</param>
        /// <param name="maxElapsedTimeMs">The maximum elapsed time in milliseconds.</param>
        /// <param name="exponent">The base factor used to compute the exponential interval</param>
        /// <param name="jitterFactor">The jitter factor used to randomize the backoff interval</param>
        public BackoffStrategy(long initialIntervalMs,
                               long maxIntervalMs,
                               long maxElapsedTimeMs,
                               double exponent,
                               double jitterFactor = 0.5)
        {
            InitialIntervalMs = initialIntervalMs;
            MaxIntervalMs = maxIntervalMs;
            MaxElapsedTimeMs = maxElapsedTimeMs;
            BaseFactor = exponent;
            JitterFactor = jitterFactor;
        }
    }
}