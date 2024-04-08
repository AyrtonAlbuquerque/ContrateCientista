using Api.Domain.Data;
using Api.Domain.Repository;
using Api.Extensions;
using Api.Handlers;
using Api.Middleware;
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


namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var url = builder.Configuration["LanguageApi:Url"];
            var key = builder.Configuration["AppSettings:Secret"];

            ArgumentException.ThrowIfNullOrEmpty(url);
            ArgumentException.ThrowIfNullOrEmpty(key);

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMemoryCache();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddMappings();
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
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Bearer Token."
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.CustomSchemaIds(Type => Type.ToString());
            });

            // Add Database
            builder.Services.AddDbContext<DataContext>(options => options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies());

            // Language API
            builder.Services.AddHttpClient<LanguageHandler>(client =>
            {
                client.BaseAddress = new Uri(url);
            });
            builder.Services.AddRefitClient<ILanguageService>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .AddHttpMessageHandler<LanguageHandler>();

            // Add Repositories
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<AddressRepository>()
                .AddClasses(classes => classes.InExactNamespaces("Api.Domain.Repository"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // Add Services
            builder.Services.Scan(scan => scan
                .FromAssemblyOf<AuthService>()
                .AddClasses(classes => classes.InExactNamespaces("Api.Services"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();
            app.ApplyMigrations();
            app.Run();
        }
    }
}