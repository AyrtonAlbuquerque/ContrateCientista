using Api.Contracts.LanguageApi;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Api.Handlers
{
    public class LanguageTokenHandler : DelegatingHandler
    {
        private IConfiguration configuration;

        public LanguageTokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = GetToken();

            request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.AccessToken);

            return base.Send(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = GetToken();

            request.Headers.Authorization = new AuthenticationHeaderValue(token.Type, token.AccessToken);

            return base.SendAsync(request, cancellationToken);
        }

        private Token GetToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["LanguageApi:Url"] ?? throw new Exception("LanguageApi Url não configurada"));

                var request = JsonSerializer.Serialize(new Login
                {
                    Usuario = configuration["LanguageApi:Username"] ?? throw new Exception("LanguageApi Username não configurado"),
                    Senha = configuration["LanguageApi:Password"] ?? throw new Exception("LanguageApi Password não configurado")
                });
                var response = client.PostAsync("auth/login", new StringContent(request, Encoding.UTF8, "application/json")).Result;

                return JsonSerializer.Deserialize<Token>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}