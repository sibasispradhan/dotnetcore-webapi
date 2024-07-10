using Microsoft.AspNetCore.Mvc;
using MyApi.BAL.Services;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            // Validate user credentials (this is just a sample, use proper validation)
            // Generate token if valid
            var token = _tokenService.GenerateToken();
            return Ok(new { Token = token });
        }
    }
}
