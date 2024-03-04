using Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
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
            try
            {
                return Ok(await authService.Login(login));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new Error
                {
                    Message = $"Ocorreu um erro ao realizar o login: {(e.InnerException ?? e).Message}"
                });
            }
        }
    }
}