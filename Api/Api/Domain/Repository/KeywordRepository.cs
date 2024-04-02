using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IKeywordRepository : IRepository<Keyword>
    {
    }

    public class KeywordRepository(DataContext context) : Repository<Keyword>(context), IKeywordRepository
    {
    }
}