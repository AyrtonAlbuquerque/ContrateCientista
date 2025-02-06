using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Benchmark.Contracts;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Benchmark.Clients.Handlers
{
    public class DemandHandler(IConfiguration configuration, HttpClient client, IMemoryCache memoryCache) : DelegatingHandler
    {
        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = Authenticate();

            request.Headers.Authorization = new AuthenticationHeaderValue(auth.Type, auth.Token);

            return base.Send(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = Authenticate();

            request.Headers.Authorization = new AuthenticationHeaderValue(auth.Type, auth.Token);

            return base.SendAsync(request, cancellationToken);
        }

        private Auth Authenticate()
        {
            if (!memoryCache.TryGetValue("DemandAuth", out Auth auth))
            {
                var request = JsonSerializer.Serialize(new Login
                {
                    Email = configuration["Api:DemandEmail"],
                    Password = configuration["Api:DemandPassword"]
                });
                var response = client.PostAsync("auth/login", new StringContent(request, Encoding.UTF8, "application/json")).Result;

                auth = JsonSerializer.Deserialize<Auth>(response.Content.ReadAsStringAsync().Result);

                memoryCache.Set("DemandAuth", auth, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = DateTimeOffset.FromUnixTimeSeconds((long?)auth?.Expires ?? 3600).UtcDateTime - DateTime.UtcNow
                });
            }

            return auth;
        }
    }
}