using Api.Contracts.LanguageApi;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Api.Handlers
{
    public class LanguageTokenHandler : DelegatingHandler
    {
        private HttpClient client;
        private IConfiguration configuration;

        public LanguageTokenHandler(IConfiguration configuration, HttpClient client)
        {
            this.client = client;
            this.configuration = configuration;
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
            var request = JsonSerializer.Serialize(new Login
            {
                Usuario = configuration["LanguageApi:Username"],
                Senha = configuration["LanguageApi:Password"]
            });
            var response = client.PostAsync("auth/login", new StringContent(request, Encoding.UTF8, "application/json")).Result;

            return JsonSerializer.Deserialize<Token>(response.Content.ReadAsStringAsync().Result);
        }
    }
}