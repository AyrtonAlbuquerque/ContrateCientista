using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;

namespace Api.Services.Interfaces
{
    public interface IDemandService
    {
        Task<CreateDemandResponse> Create(CreateDemand createDemand);
        Task<UpdateDemandResponse> Update(UpdateDemand updateDemand);
        Task Finalize(int id);
    }
}