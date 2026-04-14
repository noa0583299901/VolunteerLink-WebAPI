using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Volunteer.Entities
{
    public interface IVolunteerRepository
    {
        Task AddVolunteer(MyVolunteer volunteer);
        Task<IEnumerable<MyVolunteer>> GetAllVolunteers();
        Task<MyVolunteer> GetByEmail(string email);
        Task<MyVolunteer> GetVolunteer(int id);
        Task UpdateVolunteer(int id, MyVolunteer myVolunteer);
        Task<Skill> GetSkillByName(string name);
        Task AddSkill(Skill skill); 
        Task<List<MyVolunteer>> GetVolunteersBySkill(string skillName);
    }
}
