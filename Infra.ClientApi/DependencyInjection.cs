using Microsoft.Extensions.DependencyInjection;

namespace Infra.ClientApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientApi(this IServiceCollection services)
        {
            services.AddHttpClient("via-cep", c =>
            {
                c.BaseAddress = new Uri("https://viacep.com.br");
            }).AddPolicyHandler(PollyPolicyFactory.CreateRetryPolicy(3))
              .AddPolicyHandler(PollyPolicyFactory.CreateCircuitBreakerPolicy(5, 30))
              .AddPolicyHandler(PollyPolicyFactory.CreateTimeoutPolicy(10));

            services.AddSingleton<IResilientApiClient, ResilientApiClient>();

            return services;
        }

    }
}
