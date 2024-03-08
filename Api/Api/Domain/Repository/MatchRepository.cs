using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IMatchRepository : IRepository<Match>
    {
    }

    public class MatchRepository(DataContext context) : Repository<Match>(context), IMatchRepository
    {
    }
}