using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Volunteer.Entities;
using Volunteer.Service;
using static DTOs.Class1;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController(IVolunteerService service) : ControllerBase
    {
        // GET: api/Volunteers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolunteerDTO>>> Get()
        {
            var list = await service.GetAllVolunteers();
            return Ok(list);
        }

        // GET api/Volunteers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VolunteerDTO>> Get(int id)
        {
            var v = await service.GetVolunteer(id);

            if (v == null)
            {
                return NotFound(new { Message = $"Volunteer with ID {id} was not found." });
            }

            return Ok(v);
        }

        // POST api/Volunteers
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VolunteerPostDTO volunteer)
        {
            if (volunteer == null) return BadRequest();

            await service.AddVolunteer(volunteer);

           
            return CreatedAtAction(nameof(Get), new { id = volunteer.Email }, volunteer);
        }

        // PUT api/Volunteers/5
        [Authorize] 
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string lastName)
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || (int.Parse(userId) != id && !User.IsInRole("Admin")))
            {
                return Forbid();
            }

            var v = await service.GetVolunteer(id);
            if (v == null) return NotFound();

            await service.UpdateVolunteer(id, lastName);
            return NoContent();
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<MyVolunteer>> GetProfile()
        {
            var volunteerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (volunteerId == null)
            {
                return Unauthorized();
            }

            var result = await service.GetVolunteerProfile(int.Parse(volunteerId));
            if (result == null) return NotFound();

            return Ok(result);
        }

        [Authorize]
        [HttpPost("add-skill")]
        public async Task<IActionResult> AddSkill([FromBody] string skillName)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                int volunteerId = int.Parse(userIdClaim.Value);

                await service.AddSkillByName(volunteerId, skillName);
                return Ok(new { Message = "Skill added successfully" });
            }
            catch (Exception ex)
            {
               
                return BadRequest(new { Message = ex.Message });
            }
        }

       
        [Authorize(Roles = "Admin")]
        [HttpPost("admin/create-skill")]
        public async Task<IActionResult> CreateNewSkill([FromBody] string skillName)
        {
            try
            {
                await service.AddNewSkillToSystem(skillName);
                return Ok(new { Message = $"המיומנות {skillName} נוספה למאגר המערכת בהצלחה." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("filter/{skillName}")]
        public async Task<ActionResult<IEnumerable<VolunteerDTO>>> GetBySkill(string skillName)
        {
            var list = await service.GetVolunteersBySkill(skillName);
            return Ok(list);
        }
    }
}