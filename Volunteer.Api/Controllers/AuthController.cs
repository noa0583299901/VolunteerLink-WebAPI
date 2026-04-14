using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Entities;
using Volunteer.Service;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IVolunteerService volunteerService,JwtService jwtService) : ControllerBase
    {
       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           
            var user = await volunteerService.ValidateUser(loginDto);

            if (user == null)
            {
                return Unauthorized();
            }

            
            var token = jwtService.GenerateToken(user);

            return Ok(token);
        }
       
    }
}
