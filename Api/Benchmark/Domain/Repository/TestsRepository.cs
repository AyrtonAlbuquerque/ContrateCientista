using Benchmark.Domain.Data;
using Benchmark.Domain.Model;
using Benchmark.Domain.Repository.Base;

namespace Benchmark.Domain.Repository
{
    public interface ITestsRepository : IRepository<Tests>
    {
    }

    public class TestsRepository(Context context) : Repository<Tests>(context), ITestsRepository
    {
    }
}