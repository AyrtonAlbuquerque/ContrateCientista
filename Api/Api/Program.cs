using Api.Domain.Data;
using Api.Extensions;
using Api.Handlers;
using Api.Services;
using Api.Services.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Scrutor;
using Refit;
using System.Net.Http.Headers;


namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddRouting();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contrate um Cientista",
                    Version = "1.0",
                    Description = "API Contrate Um Cientista",
                    Contact = new OpenApiContact
                    {
                        Name = "DIREC - Universidade Tecnológica Federal do Paraná",
                        Email = "walmorgodoi@utfpr.edu.br",
                        Url = new Uri("https://utfpr.curitiba.br/direc/")
                    }
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "\"Bearer\" {token}",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.CustomSchemaIds(Type => Type.ToString());
            });

            // Add Database
            builder.Services.AddDbContext<DataContext>(options => options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies()
            );

            // Language API
            builder.Services.AddScoped<LanguageTokenHandler>();
            builder.Services.AddRefitClient<ILanguageService>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(builder.Configuration["LanguageApi:Url"] ?? throw new Exception("Language API URL não configurada.")); })
                .AddHttpMessageHandler<LanguageTokenHandler>();

            // Add Services
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<AuthService>()
                .AddClasses(classes => classes.InExactNamespaces("Api.Services"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            // Add Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "UTFPR",
                    ValidAudience = "DIREC",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"] ?? throw new Exception("Token secret não configurado.")))
                };
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.ApplyMigrations();
            app.Run();
        }
    }
}