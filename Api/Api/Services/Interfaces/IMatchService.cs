using Api.Contracts.Common;
using Api.Contracts.Demand;

namespace Api.Services.Interfaces
{
    public interface IMatchService
    {
        Task<Match> Get(int id);
        Task<IList<Match>> List(int? demand, int? laboratory);
        Task Like(Like like);
    }
}