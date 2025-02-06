using Benchmark.Contracts;
using Refit;

namespace Benchmark.Clients
{
    public interface ILaboratoryClient
    {
        [Post("/laboratory/register")]
        Task Post([Body] Laboratory laboratory);
    }
}