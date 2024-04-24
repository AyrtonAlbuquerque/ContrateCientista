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
    public class DemandController(IDemandService demandService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Demand))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<Demand>> Get(int id)
        {
            return Ok(await demandService.Get(id));
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Demand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<IList<Demand>>> Get()
        {
            return Ok(await demandService.List());
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDemandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<CreateDemandResponse>> Post(CreateDemand createDemand)
        {
            return Ok(await demandService.Create(createDemand));
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateDemandResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<UpdateDemandResponse>> Put(UpdateDemand updateDemand)
        {
            return Ok(await demandService.Update(updateDemand));
        }

        [HttpPatch("finalize/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task Patch(int id)
        {
            await demandService.Finalize(id);
        }
    }
}