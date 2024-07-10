using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Domain.Model;
using Api.Mappings.Interfaces;
using Mapster;

namespace Api.Mappings
{
    public class AuthMapping : IMapping
    {
        public void AddMappings()
        {
            TypeAdapterConfig<(User user, Token token), LoginResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.user.Id)
                .Map(dest => dest.Type, source => source.token.Type)
                .Map(dest => dest.Token, source => source.token.Value)
                .Map(dest => dest.Expires, source => source.token.Expires)
                .Map(dest => dest.UserType, source => source.user.Company != null ? 0 : 1);
        }
    }
}