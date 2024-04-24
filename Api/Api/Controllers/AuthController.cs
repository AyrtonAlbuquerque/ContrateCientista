using Microsoft.AspNetCore.Mvc;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Services.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error))]
        public async Task<ActionResult<LoginResponse>> Post(Login login)
        {
            return Ok(await authService.Login(login));
        }
    }
}