using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ITestsRepository : IRepository<Tests>
    {
    }

    public class TestsRepository(DataContext context) : Repository<Tests>(context), ITestsRepository
    {
    }
}