using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            this.laboratoryService = laboratoryService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(RegisterLaboratory register)
        {
            return Ok(await laboratoryService.Register(register));
        }
    }
}