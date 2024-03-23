using Microsoft.AspNetCore.Mvc;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Services.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(Login login)
        {
            return Ok(await authService.Login(login));
        }

        [HttpPost("register/company")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(RegisterCompany register)
        {
            return Ok(await authService.Register(register));
        }

        [HttpPost("register/laboratory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(RegisterLaboratory register)
        {
            return Ok(await authService.Register(register));
        }
    }
}