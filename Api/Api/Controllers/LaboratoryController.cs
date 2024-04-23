using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            this.laboratoryService = laboratoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Laboratory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<Laboratory>> Get()
        {
            return Ok(await laboratoryService.Get());
        }

        [HttpPost("register"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(Laboratory register)
        {
            return Ok(await laboratoryService.Register(register));
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Laboratory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<Laboratory>> Put(Laboratory laboratory)
        {
            return Ok(await laboratoryService.Update(laboratory));
        }
    }
}