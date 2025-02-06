using Benchmark.Contracts;
using Benchmark.Contracts.Responses;
using Refit;

namespace Benchmark.Clients
{
    public interface IDemandClient
    {
        [Post("/demand/create")]
        Task<DemandResponse> Post([Body] Demand demand);
    }
}