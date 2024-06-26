using Api.Contracts.Common;
using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;

namespace Api.Services.Interfaces
{
    public interface IDemandService
    {
        Task<Demand> Get(int id);
        Task<IList<Demand>> List();
        Task<CreateDemandResponse> Create(CreateDemand createDemand);
        Task<UpdateDemandResponse> Update(UpdateDemand updateDemand);
        Task Finalize(int id);
    }
}