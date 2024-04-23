using Api.Contracts.Common;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;

        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Match))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<Match>> Get(int id)
        {
            return Ok(await matchService.Get(id));
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Match>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<IList<Match>>> Get([FromQuery] int? demand, [FromQuery] int? laboratory)
        {
            return Ok(await matchService.List(demand, laboratory));
        }

        [HttpPost("like")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task Post(Like like)
        {
            await matchService.Like(like);
        }
    }
}