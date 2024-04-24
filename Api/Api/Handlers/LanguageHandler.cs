using Api.Contracts.Auth;
using Api.Contracts.Common;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Handlers
{
    public class LanguageHandler(IConfiguration configuration, HttpClient client, IMemoryCache memoryCache) : DelegatingHandler
    {
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
            if (!memoryCache.TryGetValue("token", out Token token))
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