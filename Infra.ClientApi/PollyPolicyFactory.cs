using Polly;

namespace Infra.ClientApi
{
    public static class PollyPolicyFactory
    {
        public static IAsyncPolicy<HttpResponseMessage> CreateTimeoutPolicy(int seconds)
            => Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(seconds));

        public static IAsyncPolicy<HttpResponseMessage> CreateRetryPolicy(int retries)
            => Policy<HttpResponseMessage>
                .Handle<Exception>()
                .OrResult(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(
                    retries,
                    attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));

        public static IAsyncPolicy<HttpResponseMessage> CreateCircuitBreakerPolicy(
            int failuresBeforeBreak,
            int breakSeconds)
            => Policy<HttpResponseMessage>
                .Handle<Exception>()
                .OrResult(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(
                    failuresBeforeBreak,
                    TimeSpan.FromSeconds(breakSeconds));
    }
}
