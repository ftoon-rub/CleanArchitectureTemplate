using ApplicationLayer.Interfaces.InfrastructureLayer;
using InfrastructureLayer.Security.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitectureTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGeneration _jwtTokenGeneration;

        public AuthenticationController(IJwtTokenGeneration jwtTokenGeneration)
        {
            _jwtTokenGeneration = jwtTokenGeneration;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("[action]")]
        public IActionResult TestJwtBearerAuthentication()
        {
            return Ok("JwtBearer");
        }

        [Authorize(AuthenticationSchemes = "BasicAuthentication")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult TestBasicAuthentication()
        {
            return Ok("BasicAuthentication");
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult JwtTokenGeneration()
        {
            return Ok(_jwtTokenGeneration.GenerateJwtToken());
        }

    }
}
