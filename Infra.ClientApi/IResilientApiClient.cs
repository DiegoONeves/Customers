using System.Text.Json;

namespace Infra.ClientApi
{
    public interface IResilientApiClient
    {
        Task<T?> GetAsync<T>(
            string clientName,
            string path,
            string? bearer = null,
            T? fallback = default);
    }

    public class ResilientApiClient : IResilientApiClient
    {
        private readonly IHttpClientFactory _factory;

        public ResilientApiClient(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<T?> GetAsync<T>(
            string clientName,
            string path,
            string? bearer = null,
            T? fallback = default)
        {


            var client = _factory.CreateClient(clientName);

            if (bearer is not null)
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);

            try
            {
                var res = await client.GetAsync(path);
                res.EnsureSuccessStatusCode();

                var json = await res.Content.ReadAsStringAsync();
                var value = JsonSerializer.Deserialize<T>(json);


                return value;
            }
            catch
            {
                // fallback opcional
                return fallback;
            }
        }
    }
}
