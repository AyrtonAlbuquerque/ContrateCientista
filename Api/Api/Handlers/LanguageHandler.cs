using Api.Contracts.Auth;
using Api.Contracts.LanguageApi;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Handlers
{
    public class LanguageHandler : DelegatingHandler
    {
        private HttpClient client;
        private IConfiguration configuration;
        private readonly IMemoryCache memoryCache;

        public LanguageHandler(IConfiguration configuration, HttpClient client, IMemoryCache memoryCache)
        {
            this.client = client;
            this.configuration = configuration;
            this.memoryCache = memoryCache;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = GetToken();

            request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.Value);

            return base.Send(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = GetToken();

            request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.Value);

            return base.SendAsync(request, cancellationToken);
        }

        private Token GetToken()
        {
            Token token;

            if (!memoryCache.TryGetValue("token", out token))
            {
                var request = JsonSerializer.Serialize(new Login
                {
                    Email = configuration["LanguageApi:Email"],
                    Password = configuration["LanguageApi:Password"]
                });
                var response = client.PostAsync("auth/login", new StringContent(request, Encoding.UTF8, "application/json")).Result;

                token = JsonSerializer.Deserialize<Token>(response.Content.ReadAsStringAsync().Result);

                memoryCache.Set("token", token, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = DateTimeOffset.FromUnixTimeSeconds((long?)token?.Expires ?? 3600).UtcDateTime - DateTime.UtcNow
                });
            }

            return token;
        }
    }
}