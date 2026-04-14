using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer.Entities
{
    public class MyVolunteer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = "123456";
        public DateTime? BirthDate { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();

        public string Role { get; set; } = "user";
    }
}
