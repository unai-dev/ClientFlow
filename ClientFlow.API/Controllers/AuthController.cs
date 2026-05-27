using ClientFlow.API.Interfaces;
using ClientFlow.Shared.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers
{
    [ApiController]
    [Route("v1/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDTO>> Register([FromBody] CredentialsDTO credentials)
        {
            var result = await authService.Register(credentials);
            return result is null ? BadRequest("Algo ha salido mal al registrarse") : Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDTO>> Login([FromBody] CredentialsDTO credentials)
        {
            var result = await authService.Register(credentials);
            return result is null ? BadRequest("Algo ha salido mal al iniciar sesion") : Ok(result);
        }
    }
}
