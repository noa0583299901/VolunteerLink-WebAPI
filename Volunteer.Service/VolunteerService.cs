using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;
using static DTOs.Class1;

namespace Volunteer.Service
{
    public class VolunteerService(IVolunteerRepository repo, IMapper mapper) : IVolunteerService
    {
        public async Task AddVolunteer(VolunteerPostDTO volunteer)
        {
            var volunteerToAdd = mapper.Map<MyVolunteer>(volunteer);
            await repo.AddVolunteer(volunteerToAdd);
        }

        public async Task<List<VolunteerDTO>> GetAllVolunteers()
        {
            var list = await repo.GetAllVolunteers();
            var volunteerDTOs = mapper.Map<List<VolunteerDTO>>(list);
            return volunteerDTOs;
        }

        public async Task<VolunteerDTO> GetVolunteer(int id)
        {
            var v = await repo.GetVolunteer(id);
            if (v == null)
                return null;
            var volunteerDTO = mapper.Map<VolunteerDTO>(v);
            return volunteerDTO;
        }

        public async Task<MyVolunteer> GetVolunteerProfile(int id)
        {
            var v = await repo.GetVolunteer(id);
            return v;
        }

        public async Task UpdateVolunteer(int id, string lastName)
        {
            var myVolunteer = await repo.GetVolunteer(id);
            if (myVolunteer != null)
            {
                myVolunteer.LastName = lastName + $" ({myVolunteer.LastName})";
                await repo.UpdateVolunteer(id, myVolunteer);
            }
        }

        
        public async Task<MyVolunteer> ValidateUser(LoginDto user)
        {
         
            var volunteer = await repo.GetByEmail(user.Email);

            if (volunteer == null)
                return null;

            if (volunteer.Password != user.Password)
                return null;

            return volunteer;
        }
        public async Task AddSkillByName(int volunteerId, string skillName)
        {
            var volunteer = await repo.GetVolunteer(volunteerId);
            if (volunteer == null) return;

            if (volunteer.Skills.Any(s => s.Name == skillName))
                return;

            var skill = await repo.GetSkillByName(skillName);

            if (skill != null)
            {
                volunteer.Skills.Add(skill);
                await repo.UpdateVolunteer(volunteerId, volunteer);
            }
            else
            {
               
                throw new Exception("מיומנות זו אינה קיימת במערכת. רק מנהל יכול להוסיף מיומנויות חדשות.");
            }
        }
     
        public async Task AddNewSkillToSystem(string skillName)
        {
            
            var existingSkill = await repo.GetSkillByName(skillName);
            if (existingSkill != null)
            {
                throw new Exception("המיומנות כבר קיימת במאגר המערכת.");
            }

            var newSkill = new Skill { Name = skillName };
            await repo.AddSkill(newSkill); 
        }

       
        public async Task<List<VolunteerDTO>> GetVolunteersBySkill(string skillName)
        {
            
            var filteredList = await repo.GetVolunteersBySkill(skillName);

            return mapper.Map<List<VolunteerDTO>>(filteredList);
        }
    }
}

    
