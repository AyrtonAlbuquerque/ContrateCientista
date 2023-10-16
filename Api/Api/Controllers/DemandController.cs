using Api.Contracts.LanguageApi;
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

        [HttpPost("extract")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Keyword))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Keyword>> Post(Demand demand)
        {
            try
            {
                return Ok(await demandService.ExtractKeywords(demand));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Erro = $"Ocorreu um erro ao testar extrair as palavras chaves para essa demanda. {(e.InnerException ?? e).Message}" });
            }
        }
    }
}