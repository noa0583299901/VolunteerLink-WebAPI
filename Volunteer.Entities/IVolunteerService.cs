using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTOs.Class1;

namespace Volunteer.Entities
{
    public interface IVolunteerService
    {
        Task AddVolunteer(VolunteerPostDTO volunteer);
         Task<List<VolunteerDTO>> GetAllVolunteers();
        Task<VolunteerDTO> GetVolunteer(int id);
        Task UpdateVolunteer(int id, string lastName);
        Task<MyVolunteer> ValidateUser(LoginDto user);
        Task<MyVolunteer> GetVolunteerProfile(int id);
        Task AddSkillByName(int volunteerId, string skillName);
   
        Task<List<VolunteerDTO>> GetVolunteersBySkill(string skillName);
        Task AddNewSkillToSystem(string skillName);
    }
}
