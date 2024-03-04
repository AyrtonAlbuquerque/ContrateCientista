using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IMatchRepository : IRepository<Match>
    {
    }

    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(DataContext context) : base(context)
        {
        }
    }
}