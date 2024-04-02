using Api.Contracts.Common;
using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DemandController : ControllerBase
    {
        private readonly IDemandService demandService;

        public DemandController(IDemandService demandService)
        {
            this.demandService = demandService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDemandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<CreateDemandResponse>> Post(CreateDemand createDemand)
        {
            return Ok(await demandService.Create(createDemand));
        }
    }
}