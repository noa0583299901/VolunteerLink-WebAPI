using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;

namespace Repositoryy
{
    public class VolunteerRepository(DataContext dataContext) : IVolunteerRepository
    {
        public async Task<IEnumerable<MyVolunteer>> GetAllVolunteers()
        {
           
            return await dataContext.Volunteers.Include(v => v.Skills).ToListAsync();
        }

        public async Task AddVolunteer(MyVolunteer volunteer)
        {
            dataContext.Volunteers.Add(volunteer);
            await dataContext.SaveChangesAsync();
        }

        public async Task<MyVolunteer> GetVolunteer(int id)
        {
            return await dataContext.Volunteers
                .Include(v => v.Skills) 
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateVolunteer(int id, MyVolunteer myVolunteer)
        {
            var volunteer = await dataContext.Volunteers.FirstOrDefaultAsync(v => v.Id == id);

            if (volunteer != null)
            {
                volunteer.FirstName = myVolunteer.FirstName;
                volunteer.LastName = myVolunteer.LastName;
               await dataContext.SaveChangesAsync();
            }
        }

        public async Task<MyVolunteer> GetByEmail(string email)
        {
            return await dataContext.Volunteers
                .Include(v => v.Skills)
                .FirstOrDefaultAsync(v => v.Email == email);
        }

        public async Task<Skill> GetSkillByName(string name)
        {
            return await dataContext.Skills.FirstOrDefaultAsync(s => s.Name == name);
        }
        public async Task AddSkill(Skill skill)
        {
            dataContext.Skills.Add(skill);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<MyVolunteer>> GetVolunteersBySkill(string skillName)
        {
            return await dataContext.Volunteers
                .Include(v => v.Skills) 
                .Where(v => v.Skills.Any(s => s.Name == skillName))
                .ToListAsync();
        }
    }
}