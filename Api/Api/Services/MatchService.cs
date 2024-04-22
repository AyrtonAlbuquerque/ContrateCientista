using Api.Contracts.Common;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using IListExtension;
using Mapster;

namespace Api.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUserService userService;
        private readonly IMatchRepository matchRepository;

        public MatchService(IUserService userService, IMatchRepository matchRepository)
        {
            this.userService = userService;
            this.matchRepository = matchRepository;
        }

        public async Task<Match> Get(int id)
        {
            var user = await userService.GetUserAsync();
            var match = await matchRepository.GetAsync(id);

            NotFoundException.ThrowIfNull(match, "Match não encontrado");
            ForbiddenException.ThrowIf((user.Company != null && match.Demand.Company != user.Company) || (user.Laboratory != null && match.Laboratory != user.Laboratory),
                "Usuário não possui permissão para visualizar matches da qual não está relacionado");

            return match.Adapt<Match>();
        }

        public async Task<IList<Match>> List(int? demand, int? laboratory)
        {
            var result = new List<Match>();
            var user = await userService.GetUserAsync();
            var matches = await matchRepository.SelectAsync(user, demand, laboratory);

            NotFoundException.ThrowIf(!matches.Any(), "Nenhum match encontrado");

            matches.ForEach(x => result.Add(new Match
            {
                Id = x.Id,
                Score = x.Score,
                Liked = x.Liked ?? false,
                Demand = new Demand
                {
                    Id = x.Demand.Id,
                    Title = x.Demand.Title
                },
                Laboratory = new Laboratory
                {
                    Id = x.Laboratory.Id,
                    Name = x.Laboratory.Name
                }
            }));

            return result.OrderByDescending(x => x.Score).ToList();
        }

        public async Task Like(Like like)
        {
            var user = await userService.GetUserAsync();
            var match = await matchRepository.GetAsync(like.Match);

            ForbiddenException.ThrowIfNull(user.Company, "Usuário não corresponde a uma empresa, apenas empresas podem dar like em matches");
            NotFoundException.ThrowIfNull(match, "Match não encontrado");
            ForbiddenException.ThrowIf(match.Demand.Company != user.Company, "Usuário não possui permissão para dar like em matches de outra empresa");

            match.Liked = like.Liked;

            await matchRepository.UpdateAsync(match);
        }
    }
}