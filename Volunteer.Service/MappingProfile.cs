using AutoMapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;
using static DTOs.Class1;

namespace Volunteer.Service
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<MyVolunteer, VolunteerDTO>()
                .ForMember(dest => dest.SkillNames,
                           opt => opt.MapFrom(src => src.Skills.Select(s => s.Name).ToList())); 
            CreateMap<VolunteerPostDTO, MyVolunteer>();
        }
    }
}
